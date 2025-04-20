using HireHub.Core.DTOs;
using HireHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireHub.Core.ResultModel;
using HireHub.Core.DTOs;
using HireHub.Core.Entities;

namespace HireHub.Core.IServices
{
    public interface IAuthService
    {
        public string GenerateJwtToken(User user);
        public Task<Result<Authentication>> RegisterAsync(UserDTO user);
        public Task<Result<Authentication>> LoginAsync(UserDTO user);
    }
}
