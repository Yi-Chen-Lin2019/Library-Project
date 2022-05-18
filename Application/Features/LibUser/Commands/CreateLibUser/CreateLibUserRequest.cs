using System;
using Domain.Common;
using FluentValidation;

namespace Application.Features.LibUser.Commands.CreateLibUser
{
    public class CreateLibUserRequest
    {
        public int SSN { get; set; }
        public String FName { get; set; }
        public String Surname { get; set; }
        public String Address { get; set; }
        public int Phone { get; set; }
        public String Campus { get; set; }

        public CreateLibUserRequest()
        {
        }

        public class Validator : AbstractValidator<CreateLibUserRequest>
        {
            public Validator()
            {
                RuleFor(r => r.SSN).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(SSN)).Code);
                RuleFor(r => r.FName).EmailAddress().WithMessage(Errors.General.UnexpectedValue(nameof(FName)).Code);
                RuleFor(r => r.Surname).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Surname)).Code);
                RuleFor(r => r.Address).NotEmpty().WithMessage(Errors.General.UnexpectedValue(nameof(Address)).Code);
                RuleFor(r => r.Phone).NotEmpty().WithMessage(Errors.General.UnexpectedValue(nameof(Phone)).Code);
                RuleFor(r => r.Campus).NotEmpty().WithMessage(Errors.General.UnexpectedValue(nameof(Campus)).Code);
            }
        }
    }
}
