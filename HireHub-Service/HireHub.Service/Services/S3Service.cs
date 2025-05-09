﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3.Model;
using Amazon.S3;
using Microsoft.Extensions.Configuration;
using HireHub.Core.IServices;

namespace HireHub.Service.Services
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public S3Service(IConfiguration configuration)
        {
            var accessKey = Environment.GetEnvironmentVariable("AWS_ACCESSKEY");
            var secretKey = Environment.GetEnvironmentVariable("AWS_SECRETKEY");
            var region = Environment.GetEnvironmentVariable("AWS_REGION");
            _bucketName = Environment.GetEnvironmentVariable("AWS_BUCKET_NAME") ?? throw new ArgumentNullException("AWS BucketName is missing");

            if (string.IsNullOrEmpty(accessKey) || string.IsNullOrEmpty(secretKey) || string.IsNullOrEmpty(region))
            {
                throw new ArgumentNullException("AWS credentials or region are missing");
            }
            _s3Client = new AmazonS3Client(accessKey, secretKey, Amazon.RegionEndpoint.GetBySystemName(region));
        }

        public async Task<string> GeneratePresignedUrlAsync(string folderName, string fileName, string contentType)
        {
            var key = $"{folderName}/{fileName}";
            var listRequest = new ListObjectsV2Request
            {
                BucketName = _bucketName,
                Prefix = key
            };

            var listResponse = await _s3Client.ListObjectsV2Async(listRequest);
            var existingObject = listResponse.S3Objects.FirstOrDefault(o => o.Key == key);

            if (existingObject == null)
            {
                var request = new PutObjectRequest
                {
                    BucketName = _bucketName,
                    Key = key,
                    ContentType = contentType
                };

                await _s3Client.PutObjectAsync(request);
            }

            var presignedUrlRequest = new GetPreSignedUrlRequest
            {
                BucketName = _bucketName,
                Key = key,
                Verb = HttpVerb.PUT,
                Expires = DateTime.UtcNow.AddMinutes(10),
                ContentType = contentType
            };

            return await Task.FromResult(_s3Client.GetPreSignedURL(presignedUrlRequest));
        }


        public async Task<string> GetDownloadUrlAsync(string fileName)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = _bucketName,
                Key = fileName,
                Verb = HttpVerb.GET,
                Expires = DateTime.UtcNow.AddMinutes(30)
            };

            return await Task.FromResult(_s3Client.GetPreSignedURL(request));
        }
    }
}
