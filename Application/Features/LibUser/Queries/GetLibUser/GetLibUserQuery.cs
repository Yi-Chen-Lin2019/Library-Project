using System;
using EnsureThat;

namespace Application.Features.LibUser.Queries.GetLibUser
{
    public class GetLibUserQuery
    {
        public int SSN { get; private set; }
        public GetLibUserQuery()
        {
        }

        public GetLibUserQuery(int ssn)
        {
            Ensure.That(ssn, nameof(ssn)).IsGt(0);
            this.SSN = ssn;
        }
    }
}
