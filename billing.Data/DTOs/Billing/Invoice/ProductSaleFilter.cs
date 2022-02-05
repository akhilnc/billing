using System;
using System.Collections.Generic;
using System.Text;

namespace billing.Data.DTOs.Billing.Invoice
{
    public class ProductSaleFilter
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
