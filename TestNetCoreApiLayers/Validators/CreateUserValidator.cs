using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNetCore.Core.Dto;

namespace TestNetCore.Api.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Lastname)
               .NotEmpty()
               .MaximumLength(50);
            RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(50);
            RuleFor(x => x.Phones)
                .NotEmpty();
        }
    }
}
