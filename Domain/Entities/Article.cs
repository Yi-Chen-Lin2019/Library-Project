using System;
using Domain.AggregateRoots;
using Domain.Common;

namespace Domain.Entities
{
    public class Article : Entity, IItemDescriptor
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public String Author { get; set; }
        public String Title { get; set; }
        public Borrow_Type Borrow_Type { get; set; }
        public String Description { get; set; }
        public String Publisher { get; set; }
        public String Subject { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Article(int Year, String Author, String Title, Borrow_Type Borrow_Type, String Description, String Publisher, String Subject, DateTime ReleaseDate)
        {
            this.Year = Year;
            this.Author = Author;
            this.Title = Title;
            this.Borrow_Type = Borrow_Type;
            this.Description = Description;
            this.Publisher = Publisher;
            this.Subject = Subject;
            this.ReleaseDate = ReleaseDate;
        }
        public Article(int ID, int Year, String Author, String Title, Borrow_Type Borrow_Type, String Description, String Publisher, String Subject, DateTime ReleaseDate)
        {
            this.ID = ID;
            this.Year = Year;
            this.Author = Author;
            this.Title = Title;
            this.Borrow_Type = Borrow_Type;
            this.Description = Description;
            this.Publisher = Publisher;
            this.Subject = Subject;
            this.ReleaseDate = ReleaseDate;
        }
    }
}
