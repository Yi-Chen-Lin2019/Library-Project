using System;
using Domain.Common;

namespace Domain.Entities
{
    public class LibraryCard : Entity
    {
        public int CardID { get; set; }
        public DateTime PrintDate { get; set; }
        public int UserSSN { get; set; }

        public LibraryCard()
        {
        }
    }
}
