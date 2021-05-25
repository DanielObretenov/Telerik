using System;
using System.Collections.Generic;
using System.Text;

namespace Telerik.Common.Data.BillingInformation
{
     public class LicenseHolderInformation : UserInformation
    {

        public bool IsSameAsBilling { get; set; }
        public LicenseHolderInformation(
            string firstName,
            string lastName,
            string email,
            string company,
            Address address,
            bool isSameAsAddress)
            : base(firstName, lastName, email, company, address)
        {
            IsSameAsBilling = isSameAsAddress;
        }

    }
}
