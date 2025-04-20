using FluentValidation;
using HireHub.Core.DTOs;
using HireHub.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireHub.Service.Validators
{
    public class UserUpdateValidator : AbstractValidator<UserDTO>
    {
        public UserUpdateValidator()
        {
            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("First-Name is required.");

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Last-Name is required.");
        }
    }
}
