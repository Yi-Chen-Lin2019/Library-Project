using System;
using System.Collections.Generic;
using Domain.AggregateRoots;
using EnsureThat;

namespace Application.Features.LibUser.Dto
{
    public class LibUserDto
    {
        public int SSN { get; set; }
        public String FName { get; set; }
        public String Surname { get; set; }
        public String Address { get; set; }
        public int Phone { get; set; }
        public String Campus { get; set; }
        public MemberTypeDto MemberType { get; set; }
        public LibrarianTypeDto LibrarianType { get; set; }
        public List<LibraryCardDto> LibraryCards { get; private set; }

        public LibUserDto()
        {
            LibraryCards = new List<LibraryCardDto>();
        }

        public LibUserDto(int SSN, String fName, String surname, string address, int phone, string campus,
            MemberTypeDto memberType, LibrarianTypeDto librarianType)
        {
            this.SSN = SSN;
            this.FName = fName;
            this.Surname = surname;
            this.Address = address;
            this.Campus = campus;
            this.MemberType = memberType;
            this.LibrarianType = librarianType;
            this.LibraryCards = new List<LibraryCardDto>();
        }

        public enum MemberTypeDto
        {
            NULL, Professor, Student
        }

        public enum LibrarianTypeDto
        {
            NULL, Admin, HeadLibrarian, Librarian, Intern
        }
    }
}
