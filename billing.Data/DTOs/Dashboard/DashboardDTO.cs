using billing.Data.DTOs.Masters;
using System;
using System.Collections.Generic;
using System.Text;

namespace billing.Data.DTOs.Dashboard
{
    public class DashboardDTO
    {
        public int CustomerCount { get; set; }
        public int InvoiceCount { get; set; }
        public int TotalRevenue { get; set; }
    }
}
