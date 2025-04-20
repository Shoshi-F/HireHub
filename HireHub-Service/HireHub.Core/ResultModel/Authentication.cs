using HireHub.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireHub.Core.ResultModel
{
    public class Authentication
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }

        public Authentication(string token, UserDTO user)
        {
            Token = token;
            User = user;
        }
    }
}
