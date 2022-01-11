using System;
using System.Collections.Generic;
using System.Text;

namespace billing.Data.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int Amount{ get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public MstService Service { get; set; }
    }
}
