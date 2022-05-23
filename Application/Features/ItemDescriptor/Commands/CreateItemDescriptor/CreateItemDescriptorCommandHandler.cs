using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Common;
using Domain.Entities;

namespace Application.Features.ItemDescriptor.Commands.CreateItemDescriptor
{
    public class CreateItemDescriptorCommandHandler : ICommandHandler<CreateItemDescriptorCommand>
    {
        private IItemDescriptorRepository itemRepository;

        public CreateItemDescriptorCommandHandler(IItemDescriptorRepository itemDescriptorRepository)
        {
            this.itemRepository = itemDescriptorRepository;
        }

        public async Task<Result> Handle(CreateItemDescriptorCommand command, CancellationToken cancellationToken = default)
        {
            Domain.AggregateRoots.ItemDescriptor itemDescriptor = null;
            switch (command.ItemDescriptorType)
            {
                case Domain.AggregateRoots.ItemDescriptorType.Article:
                    itemDescriptor = new Article() {
                        Year = command.Year,
                        Author = command.Author,
                        Title = command.Title,
                        Description = command.Description,
                        Publisher = command.Publisher,
                        BorrowType = command.BorrowType,
                        ItemDescriptorType = command.ItemDescriptorType,
                        Subject = command.Subject,
                        ReleaseDate = command.ReleaseDate
                    };
                    break;
                case Domain.AggregateRoots.ItemDescriptorType.Book:
                    itemDescriptor = new Book()
                    {
                        Year = command.Year,
                        Author = command.Author,
                        Title = command.Title,
                        Description = command.Description,
                        Publisher = command.Publisher,
                        BorrowType = command.BorrowType,
                        ItemDescriptorType = command.ItemDescriptorType,
                        ISBN = command.ISBN,
                        Subject = command.Subject,
                        Edition = command.Edition
                    };
                    break;
                case Domain.AggregateRoots.ItemDescriptorType.Map:
                    itemDescriptor = new Map() {
                        Year = command.Year,
                        Author = command.Author,
                        Title = command.Title,
                        Description = command.Description,
                        Publisher = command.Publisher,
                        BorrowType = command.BorrowType,
                        ItemDescriptorType = command.ItemDescriptorType
                    };
                    break;
                default:
                    break;
            }

            var itemDescriptorId = await this.itemRepository.AddAsync(itemDescriptor);
            return Result.Ok(itemDescriptorId);
        }
    }
}
