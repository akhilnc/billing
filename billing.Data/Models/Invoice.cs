using System;
using System.Collections.Generic;
using System.Text;

namespace billing.Data.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int CustomerId { get; set; }
        public int Discount { get; set; }
        public int SubTotal { get; set; }
        public int ServiceCharge { get; set; }
        public int TotalAmount { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
        public MstCustomer Customer { get; set; }

    }
}
