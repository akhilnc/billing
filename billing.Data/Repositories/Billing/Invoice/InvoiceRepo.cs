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
            return await _appContext.Invoice.Include(c=>c.Customer).Include(i => i.InvoiceItems).ThenInclude(s => s.Service).ToListAsync();
        }

        public async Task<Models.Invoice> GetInvoiceById(int id)
        {
            return await _appContext.Invoice.Include(c => c.Customer).Include(i => i.InvoiceItems).ThenInclude(s => s.Service).Where(x=>x.Id==id).FirstOrDefaultAsync();
        }

        public async Task<string> GetInvoiceNo()
        {
            var lastInvoice = await _appContext.Invoice.OrderByDescending(x => x.Id)?.FirstOrDefaultAsync();
            string lastInvoiceId="";
            if (lastInvoice != null)
            {
                lastInvoiceId  = lastInvoice.InvoiceNo;

            }
            return lastInvoiceId;
        }
    }
}
