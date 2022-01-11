using billing.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
