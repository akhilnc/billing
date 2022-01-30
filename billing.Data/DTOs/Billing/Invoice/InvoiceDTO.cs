using System;
using System.Collections.Generic;

namespace billing.Data.DTOs.Masters
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int CustomerId { get; set; }
        public CustomerDTO Customer { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ServiceCharge { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public List<InvoiceItemDTO> InvoiceItems { get; set; }
    }
}
