using System;
using System.Collections.Generic;

namespace billing.Data.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int CustomerId { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
        public MstCustomer Customer { get; set; }

    }
}
