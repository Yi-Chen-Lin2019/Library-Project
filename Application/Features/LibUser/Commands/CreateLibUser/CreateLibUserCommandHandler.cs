using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.AggregateRoots;
using Domain.Common;

namespace Application.Features.LibUser.Commands.CreateLibUser
{
    public class CreateLibUserCommandHandler : ICommandHandler<CreateLibUserCommand>
    {
        private ILibUserRepository libUserRepository;

        public CreateLibUserCommandHandler(ILibUserRepository libUserRepository)
        {
            this.libUserRepository = libUserRepository;
        }

        public async Task<Result> Handle(CreateLibUserCommand command, CancellationToken cancellationToken = default)
        {
            /*
            MemberType memberType = command.MemberType.Equals(Dto.LibUserDto.MemberTypeDto.Professor) ? MemberType.Professor : MemberType.Student;
            LibrarianType librarianType = LibrarianType.Librarian;
            switch (command.LibrarianType)
            {
                case Dto.LibUserDto.LibrarianTypeDto.Admin:
                    librarianType = LibrarianType.Admin;
                    break;
                case Dto.LibUserDto.LibrarianTypeDto.HeadLibrarian:
                    librarianType = LibrarianType.HeadLibrarian;
                    break;
                default:
                    break;
            }
            */
            var libUser = new Domain.AggregateRoots.LibUser(
                command.SSN, command.FName, command.Surname, command.Address, command.Phone, command.Campus);
            var libUserId = await this.libUserRepository.AddAsync(libUser);
            return Result.Ok(libUserId);
        }
    }
}
