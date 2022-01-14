using billing.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace billing.Data.Repositories.Billing.Invoice
{
    public interface IInvoiceRepo: IRepositoryBase<billing.Data.Models.Invoice>
    {
        Task<IEnumerable<billing.Data.Models.Invoice>> GetAllInvoice();
    }
}
