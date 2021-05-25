using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Common.Enums;

namespace Telerik.Common.Data.BillingInformation
{
    public class Address
    {
        public string AddressInfo { get; set; }
        public CountryEnum Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public Address(string addressInfo, CountryEnum country, string state, string city, string zip)
        {
            AddressInfo = addressInfo;
            Country = country;
            State = state;
            City = city;
            Zip = zip;
        }
        public Address(string addressInfo, CountryEnum country, string city, string zip)
        {
            AddressInfo = addressInfo;
            Country = country;
            City = city;
            Zip = zip;
        }
    }
}
