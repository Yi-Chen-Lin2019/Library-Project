using System;
using System.Collections.Generic;
using Domain.AggregateRoots;
using Domain.Common;
using FluentValidation;

namespace Application.Features.ItemDescriptor.Commands.CreateItemDescriptor
{
    public class CreateItemDescriptorRequest
    {
        public int Year { get; set; }
        public String Author { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Publisher { get; set; }
        public List<Dto.ItemDto> Items { get; set; }
        public Borrow_Type BorrowType { get; set; }
        public ItemDescriptorType ItemDescriptorType { get; set; }
        public String Subject { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ISBN { get; set; }
        public int Edition { get; set; }

        public CreateItemDescriptorRequest()
        {
        }

        public class Validator : AbstractValidator<CreateItemDescriptorRequest>
        {
            public Validator()
            {
                RuleFor(r => r.Year).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Year)).Code);
                RuleFor(r => r.Author).NotEmpty().WithMessage(Errors.General.UnexpectedValue(nameof(Author)).Code);
                RuleFor(r => r.Title).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Title)).Code);
                RuleFor(r => r.Description).NotEmpty().WithMessage(Errors.General.UnexpectedValue(nameof(Description)).Code);
                RuleFor(r => r.Publisher).NotEmpty().WithMessage(Errors.General.UnexpectedValue(nameof(Publisher)).Code);
                RuleFor(r => r.BorrowType).IsInEnum().WithMessage(Errors.General.UnexpectedValue(nameof(BorrowType)).Code);
                RuleFor(r => r.ItemDescriptorType).IsInEnum().WithMessage(Errors.General.UnexpectedValue(nameof(ItemDescriptorType)).Code);
                RuleFor(r => r.Subject).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Subject)).Code);
                RuleFor(r => r.ReleaseDate).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(ReleaseDate)).Code);
                RuleFor(r => r.ISBN).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(ISBN)).Code);
                RuleFor(r => r.Edition).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Edition)).Code);
            }
        }
    }
}
