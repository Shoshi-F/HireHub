using HireHub.Core.Entities;
using System.Data;

namespace HireHub.Api.PostModels
{
    public class UserPostModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

