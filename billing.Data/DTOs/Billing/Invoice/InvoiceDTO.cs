using System;
using System.Collections.Generic;
using System.Text;

namespace billing.Data.DTOs.Masters
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public int CustomerId { get; set; }
        public CustomerDTO Customer { get; set; }
        public int Discount { get; set; }
        public int SubTotal { get; set; }
        public int TotalAmount { get; set; }
        public int ServiceCharge { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public List<InvoiceItemDTO> InvoiceItems { get; set; }
    }
}
