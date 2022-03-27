﻿
namespace billing.Data.DTOs.Masters
{
    public class InvoiceItemDTO
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public ServiceDTO Service { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public int InvoiceId { get; set; }
    }
}
