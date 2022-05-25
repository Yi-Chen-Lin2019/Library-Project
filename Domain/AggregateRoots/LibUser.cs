using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Entities;
using EnsureThat;

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
        public List<LibraryCard> LibraryCards { get; private set; }

        public LibUser()
        {
            this.LibraryCards = new List<LibraryCard>();
        }

        public LibUser(int SSN, String fName, String surname, string address, int phone, string campus,
            MemberType memberType, LibrarianType librarianType)
        {
            this.SSN = SSN;
            this.FName = fName;
            this.Surname = surname;
            this.Address = address;
            this.Campus = campus;
            this.MemberType = memberType;
            this.LibrarianType = librarianType;
            this.LibraryCards = new List<LibraryCard>();
        }

        public LibUser(int ssn, string fName, string surname, string address, int phone, string campus)
        {
            SSN = ssn;
            FName = fName;
            Surname = surname;
            Address = address;
            Phone = phone;
            Campus = campus;
        }

        public void AddLibraryCard(LibraryCard card)
        {
            this.LibraryCards.Add(card);
        }


    }

    public enum MemberType
    {
        NULL, Professor, Student
    }

    public enum LibrarianType
    {
        NULL, Admin, HeadLibrarian, Librarian, Intern
    }

}
