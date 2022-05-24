using System;
using Domain.AggregateRoots;

namespace Domain.Entities
{
    public class Book : ItemDescriptor
    {   
        public int ISBN { get; set; }
        public String Subject { get; set; }
        public int Edition { get; set; }

        public Book(int ID, int Year, String Author, String Title, BorrowType BorrowType, String Description, String Publisher, int ISBN, String Subject, int Edition)
        {
            this.ID = ID;
            this.Year = Year;
            this.Author = Author;
            this.Title = Title;
            this.Borrow_Type = BorrowType;
            this.Description = Description;
            this.Publisher = Publisher;
            this.ISBN = ISBN;
            this.Subject = Subject;
            this.Edition = Edition;
        }

        public Book(int Year, String Author, String Title, BorrowType BorrowType, String Description, String Publisher, int ISBN, String Subject, int Edition)
        {
            this.Year = Year;
            this.Author = Author;
            this.Title = Title;
            this.Borrow_Type = BorrowType;
            this.Description = Description;
            this.Publisher = Publisher;
            this.ISBN = ISBN;
            this.Subject = Subject;
            this.Edition = Edition;
        }
    }
}
