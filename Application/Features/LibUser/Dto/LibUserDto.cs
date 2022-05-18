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
        public MemberType MemberType { get; set; }
        public LibrarianType LibrarianType { get; set; }

        public LibUserDto()
        {
        }

        public LibUserDto(int SSN, String fName, String surname, string address, int phone, string campus,
            MemberType memberType, LibrarianType librarianType)
        {
            Ensure.That(fName, nameof(fName)).IsNotNullOrEmpty();
            Ensure.That(surname, nameof(surname)).IsNotNullOrEmpty();
            Ensure.That(address, nameof(address)).IsNotNullOrEmpty();
            Ensure.That(campus, nameof(campus)).IsNotNullOrEmpty();
            this.SSN = SSN;
            this.FName = fName;
            this.Surname = surname;
            this.Address = address;
            this.Campus = campus;
            this.MemberType = memberType;
            this.LibrarianType = librarianType;
        }
    }
}
