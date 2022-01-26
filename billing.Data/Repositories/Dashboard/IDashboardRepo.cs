using billing.Data.DTOs.Dashboard;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace billing.Data.Repositories.Dashboard
{
    public interface IDashboardRepo
    {
        Task<DashboardDTO> GetDashboardData();
        Task<IEnumerable<billing.Data.Models.Invoice>> GetRecentInvoices();
    }
}
