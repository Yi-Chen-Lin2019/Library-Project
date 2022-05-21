using System;
using Domain.AggregateRoots;
using static Application.Features.LibUser.Dto.LibUserDto;

namespace Application.Features.LibUser.Commands.CreateLibUser
{
    public class CreateLibUserCommand : ICommand
    {
        public int SSN { get; private set; }
        public String FName { get; private set; }
        public String Surname { get; private set; }
        public String Address { get; private set; }
        public int Phone { get; private set; }
        public String Campus { get; private set; }
        public MemberTypeDto MemberType { get; set; }
        public LibrarianTypeDto LibrarianType { get; set; }

        public CreateLibUserCommand(int ssn, String fName, String surname, String address, int phone,
            string campus, MemberTypeDto memberType, LibrarianTypeDto librarianType)
        {
            this.SSN = ssn;
            this.FName = fName;
            this.Surname = surname;
            this.Address = address;
            this.Phone = phone;
            this.Campus = campus;
            this.MemberType = memberType;
            this.LibrarianType = librarianType;
        }
    }
}
