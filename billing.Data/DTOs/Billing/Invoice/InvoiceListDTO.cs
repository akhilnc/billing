using billing.Data.DTOs.Masters;
using System;
using System.Collections.Generic;
using System.Text;

namespace billing.Data.DTOs.Billing.Invoice
{
    public class InvoiceListDTO
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public int TotalAmount { get; set; }
        public DateTime CreatedOn { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}
