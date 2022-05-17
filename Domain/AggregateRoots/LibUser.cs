using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Entities;

namespace Domain.AggregateRoots
{
    public class LibUser : AggregateRoot
    {
        public int SSN { get; set; }
        public String FName { get; set; }
        public String Surname { get; set; }
        public String Address { get; set; }
        public int Phone { get; set; }
        public String Campus { get; set; }
        public MemberType MemberType { get; set; }
        public LibrarianType LibrarianType { get; set; }
        public List<LibraryCard> LibraryCards { get; set; }

        public LibUser()
        {
        }
    }

    public enum MemberType
    {
        Professor, Student
    }

    public enum LibrarianType
    {
        Admin
    }

}
