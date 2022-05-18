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
            Ensure.That(card, nameof(card)).IsNotNull();
            this.LibraryCards.Add(card);
        }


    }

    public enum MemberType
    {
        Professor, Student
    }

    public enum LibrarianType
    {
        Admin, HeadLibrarian, Librarian
    }

}
