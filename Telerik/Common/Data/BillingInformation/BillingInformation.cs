using System;
using System.Collections.Generic;
using System.Text;

namespace Telerik.Common.Data.BillingInformation
{
    public class BillingInformation : UserInformation
    {
        public string Phone { get; set; }
        public string VatID { get; set; }
        public BillingInformation(
            string firstName,
            string lastName,
            string email, 
            string company, 
            string phone,
            Address address) 
            : base(firstName, lastName, email, company, address)
        {
            Phone = phone;
        }
    }
}
