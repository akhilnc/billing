using billing.Data.DTOs.Billing.Invoice;
using billing.Data.DTOs.Dashboard;
using billing.Data.DTOs.Masters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace billing.Service.Dashboard
{
    public interface IDashboardService
    {
        Task<DashboardDTO> GetDashboardData();
        Task<IEnumerable<InvoiceListDTO>> GetRecentInvoices();
    }
}
