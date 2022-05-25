using System;
using Domain.AggregateRoots;

namespace Domain.Entities
{
    public class Map : ItemDescriptor
    { 

        public Map(int ID, int Year, String Author, String Title, BorrowType BorrowType, String Description, String Publisher)
        {
            this.ID = ID;
            this.Year = Year;
            this.Author = Author;
            this.Title = Title;
            this.Borrow_Type = BorrowType;
            this.Description = Description;
            this.Publisher = Publisher;
        }

        public Map(int Year, String Author, String Title, BorrowType BorrowType, String Description, String Publisher)
        {
            this.Year = Year;
            this.Author = Author;
            this.Title = Title;
            this.Borrow_Type = BorrowType;
            this.Description = Description;
            this.Publisher = Publisher;
        }

        public Map()
        {
        }
    }
}
