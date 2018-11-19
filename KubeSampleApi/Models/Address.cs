using System;
using System.Collections.Generic;

namespace KubeSampleApi.Models
{
    public partial class Address
    {
        public Address()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
            SalesOrderHeaderBillToAddresses = new HashSet<SalesOrderHeader>();
            SalesOrderHeaderShipToAddresses = new HashSet<SalesOrderHeader>();
        }

        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryRegion { get; set; }
        public string PostalCode { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public ICollection<SalesOrderHeader> SalesOrderHeaderBillToAddresses { get; set; }
        public ICollection<SalesOrderHeader> SalesOrderHeaderShipToAddresses { get; set; }
    }
}
