﻿using FluentValidation;
using HireHub.Core.Entities;
using HireHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireHub.Service.Validators
{
    public class RegisterValidator : AbstractValidator<User>
    {
        public RegisterValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");

            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("First Name is required.");

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Last Name is required.");
        }
    }
}
