using System;
using Domain.Common;
using FluentValidation;
using static Application.Features.LibUser.Dto.LibUserDto;

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
        public MemberTypeDto MemberType { get; set; }
        public LibrarianTypeDto LibrarianType { get; set; }

        public CreateLibUserRequest()
        {
        }

        public class Validator : AbstractValidator<CreateLibUserRequest>
        {
            public Validator()
            {
                RuleFor(r => r.SSN).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(SSN)).Code);
                RuleFor(r => r.FName).NotEmpty().WithMessage(Errors.General.UnexpectedValue(nameof(FName)).Code);
                RuleFor(r => r.Surname).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Surname)).Code);
                RuleFor(r => r.Address).NotEmpty().WithMessage(Errors.General.UnexpectedValue(nameof(Address)).Code);
                RuleFor(r => r.Phone).NotEmpty().WithMessage(Errors.General.UnexpectedValue(nameof(Phone)).Code);
                RuleFor(r => r.Campus).NotEmpty().WithMessage(Errors.General.UnexpectedValue(nameof(Campus)).Code);
                RuleFor(r => r.MemberType).IsInEnum().WithMessage(Errors.General.UnexpectedValue(nameof(MemberType)).Code);
                RuleFor(r => r.LibrarianType).IsInEnum().WithMessage(Errors.General.UnexpectedValue(nameof(LibrarianType)).Code);
            }
        }
    }
}
