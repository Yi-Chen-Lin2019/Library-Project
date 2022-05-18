using System;
namespace Application.Features.LibUser.Dto
{
    public class LibraryCardDto
    {
        public int CardID { get; set; }
        public DateTime PrintDate { get; set; }
        public int UserSSN { get; set; }

        public LibraryCardDto()
        {
        }

        public LibraryCardDto(int cardID, DateTime printDate, int userSSN)
        {
            this.CardID = cardID;
            this.PrintDate = printDate;
            this.UserSSN = userSSN;
        }
    }
}
