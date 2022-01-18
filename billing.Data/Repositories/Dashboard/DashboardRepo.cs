using billing.Data.DTOs.Dashboard;
using billing.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace billing.Data.Repositories.Dashboard
{
    public class DashboardRepo : IDashboardRepo
    {
        private readonly DbContexts.BillingAppContext _appContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepo"/> class.
        /// </summary>
        /// <param name="appContext">The application context.</param>
        public DashboardRepo(DbContexts.BillingAppContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<DashboardDTO> GetDashboardData()
        {
            var InvoiceCount = await _appContext.Invoice.CountAsync();
            var customerCount = await _appContext.Invoice.Select(i => i.CustomerId).Distinct().CountAsync();
            var TotalRevenue = await _appContext.Invoice.SumAsync(i=>i.TotalAmount);
            var data = new DashboardDTO
            {
                InvoiceCount = InvoiceCount,
                CustomerCount= customerCount,
                TotalRevenue= TotalRevenue
            };
            return data;
        }

        public async Task<IEnumerable<billing.Data.Models.Invoice>> GetRecentInvoices()
        {
            return await _appContext.Invoice.Include(c => c.Customer).Take(5).ToListAsync();
        }
    }
}
