using System;
using Domain.AggregateRoots;

namespace Domain.Entities
{
    public class Article : ItemDescriptor
    {
        public String Subject { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Article(int ID, int Year, String Author, String Title, BorrowType BorrowType, String Description, String Publisher, String Subject, DateTime ReleaseDate)
        {
            this.ID = ID;
            this.Year = Year;
            this.Author = Author;
            this.Title = Title;
            this.Borrow_Type = BorrowType;
            this.Description = Description;
            this.Publisher = Publisher;
            this.Subject = Subject;
            this.ReleaseDate = ReleaseDate;
        }

        public Article(int Year, String Author, String Title, BorrowType BorrowType, String Description, String Publisher, String Subject, DateTime ReleaseDate)
        {
            this.Year = Year;
            this.Author = Author;
            this.Title = Title;
            this.Borrow_Type = BorrowType;
            this.Description = Description;
            this.Publisher = Publisher;
            this.Subject = Subject;
            this.ReleaseDate = ReleaseDate;
        }

        public Article()
        {
        }
    }
}
