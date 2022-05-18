using System;
using Domain.AggregateRoots;

namespace Application.Features.LibUser.Commands.CreateLibUser
{
    public class CreateLibUserCommand : ICommand
    {
        public int SSN { get; set; }
        public String FName { get; set; }
        public String Surname { get; set; }
        public String Address { get; set; }
        public int Phone { get; set; }
        public String Campus { get; set; }

        public CreateLibUserCommand(int ssn, String fName, String surname, String address, int phone, string campus)
        {
            this.SSN = ssn;
            this.FName = fName;
            this.Surname = surname;
            this.Address = address;
            this.Phone = phone;
            this.Campus = campus;
        }
    }
}
