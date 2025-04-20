using AutoMapper;
using HireHub.Api.PostModels;
using HireHub.Api.PutEntities;
using HireHub.Api.PutModels;
using HireHub.Core.DTOs;
using HireHub.Core.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace HireHub.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Jobs, JobsPostModel>().ReverseMap();
            //CreateMap<User, LoginModel>().ReverseMap();
            //CreateMap<User, RegisterModel>().ReverseMap();

            CreateMap<Jobs, JobsPutModel>().ReverseMap();
            CreateMap<User, UserPutModel>().ReverseMap();

            CreateMap<JobsDTO, Jobs>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<Resumes, ResumesDTO>().ReverseMap();
            CreateMap<Applications, ApplicationsDTO>().ReverseMap();

            CreateMap<JobsDTO, JobsPostModel>().ReverseMap();
            //CreateMap<UserDTO, LoginModel>().ReverseMap();
            //CreateMap<UserDTO, RegisterModel>().ReverseMap();

            CreateMap<JobsPutModel, JobsDTO>();
        }
    }
}