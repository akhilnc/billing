using System;
using System.Collections.Generic;
using System.Text;

namespace billing.Data.Models
{
    public class CompanySettings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Logo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }

    }
}
