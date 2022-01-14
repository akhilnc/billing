using System;
using System.Collections.Generic;
using System.Text;

namespace billing.Data.DTOs.Masters
{
    public class InvoiceItemDTO
    {
        public int Id { get; set; }
        public ServiceDTO Service { get; set; }
        public int Amount { get; set; }
        public int InvoiceId { get; set; }
    }
}
