using billing.Data.DTOs.Billing.Invoice;
using billing.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace billing.Data.Repositories.Billing.Invoice
{
    public class InvoiceRepo : RepositoryBase<billing.Data.Models.Invoice>, IInvoiceRepo
    {
        private readonly DbContexts.BillingAppContext _appContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepo"/> class.
        /// </summary>
        /// <param name="appContext">The application context.</param>
        public InvoiceRepo(DbContexts.BillingAppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }
        public async Task<IEnumerable<billing.Data.Models.Invoice>> GetAllInvoice()
        {
            return await _appContext.Invoice.Include(c => c.Customer).Include(i => i.InvoiceItems).ThenInclude(s => s.Service).ToListAsync();
        }

        public async Task<Models.Invoice> GetInvoiceById(int id)
        {
            return await _appContext.Invoice.Include(c => c.Customer).Include(i => i.InvoiceItems).ThenInclude(s => s.Service).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<string> GetInvoiceNo()
        {
            var lastInvoice = await _appContext.Invoice.OrderByDescending(x => x.Id)?.FirstOrDefaultAsync();
            string lastInvoiceId = "";
            if (lastInvoice != null)
            {
                lastInvoiceId = lastInvoice.InvoiceNo;

            }
            return lastInvoiceId;
        }

        public async Task<IEnumerable<Models.Invoice>> GetInvoices(int customerId)
        {
            return await _appContext.Invoice.Where(x => x.CustomerId == customerId).Include(c => c.Customer).Include(i => i.InvoiceItems).ThenInclude(s => s.Service).ToListAsync();
        }

        public async Task<IEnumerable<ProductSaleReportDTO>> GetProductSale()
        {
            var a = await _appContext.Invoice.Join(_appContext.InvoiceItem, i => i.Id, it => it.InvoiceId, (i, it) => new { i, it }).Join(_appContext.MstService, iit => iit.it.ServiceId, service => service.Id, (it, service) => new { ProductName = service.Name, quantity = it.it.Quantity,invoice=it.i }).Where(x=>x.invoice.CreatedOn>=DateTime.Now.Date).GroupBy(x => x.ProductName).Select(x => new ProductSaleReportDTO { ProductName = x.Key, Quantity = x.Sum(a => a.quantity) }).ToListAsync();
            // var b = _appContext.Invoice.Join(_appContext.InvoiceItem, it => it.Id, i => i.InvoiceId, (it, i) => new { it, i }).Join(_appContext.MstService, s => s.i.ServiceId, service => service.Id, (s, service) => new { ProductName = service.Name }).ToListAsync();
            return a;
        }
    }
}
