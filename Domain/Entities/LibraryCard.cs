using System;
using Domain.Common;

namespace Domain.Entities
{
    public class LibraryCard : Entity
    {
        public int CardID { get; set; }
        public DateTime PrintDate { get; set; }
        public int UserSSN { get; set; }

        public LibraryCard(int CardID, DateTime PrintDate, int UserSSN)
        {
            this.CardID = CardID;
            this.PrintDate = PrintDate;
            this.UserSSN = UserSSN;
        }

        public LibraryCard(DateTime PrintDate, int UserSSN)
        {
            this.PrintDate = PrintDate;
            this.UserSSN = UserSSN;
        }
    }
}
