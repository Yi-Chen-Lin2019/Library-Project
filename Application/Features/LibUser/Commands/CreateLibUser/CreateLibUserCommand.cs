using System;
using Domain.AggregateRoots;

namespace Application.Features.LibUser.Commands.CreateLibUser
{
    public class CreateLibUserCommand : ICommand
    {
        public int SSN { get; }
        public String FName { get; }
        public String Surname { get; }
        public String Address { get; }
        public int Phone { get; }
        public String Campus { get; }

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
