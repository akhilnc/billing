using billing.Data.DTOs.Masters;
using System;


namespace billing.Data.DTOs.Billing.Invoice
{
    public class InvoiceListDTO
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedOn { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}
