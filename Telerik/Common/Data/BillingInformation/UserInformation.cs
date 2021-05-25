using System;
using System.Collections.Generic;
using System.Text;

namespace Telerik.Common.Data.BillingInformation
{
    public abstract class UserInformation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public Address Address { get; set; }

        protected UserInformation(string firstName, string lastName, string email, string company, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Company = company;
            Address = address;
        }

     
     
    }
}
