using System;
using Domain.AggregateRoots;
using Domain.Common;

namespace Domain.Entities
{
    public class Book : Entity, IItemDescriptor
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public String Author { get; set; }
        public String Title { get; set; }
        public Borrow_Type Borrow_Type { get; set; }
        public String Description { get; set; }
        public String Publisher { get; set; }
        public int ISBN { get; set; }
        public String Subject { get; set; }
        public int Edition { get; set; }
        public Book(int Year, String Author, String Title, Borrow_Type Borrow_Type, String Description, String Publisher, int ISBN, String Subject, int Edition)
        {
            this.Year = Year;
            this.Author = Author;
            this.Title = Title;
            this.Borrow_Type = Borrow_Type;
            this.Description = Description;
            this.Publisher = Publisher;
            this.ISBN = ISBN;
            this.Subject = Subject;
            this.Edition = Edition;
        }
        public Book(int ID, int Year, String Author, String Title, Borrow_Type Borrow_Type, String Description, String Publisher, int ISBN, String Subject, int Edition)
        {
            this.ID = ID;
            this.Year = Year;
            this.Author = Author;
            this.Title = Title;
            this.Borrow_Type = Borrow_Type;
            this.Description = Description;
            this.Publisher = Publisher;
            this.ISBN = ISBN;
            this.Subject = Subject;
            this.Edition = Edition;
        }
    }
}
