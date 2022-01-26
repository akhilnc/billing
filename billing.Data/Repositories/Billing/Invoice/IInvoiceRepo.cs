using billing.Data.DTOs.Billing.Invoice;
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
        Task<billing.Data.Models.Invoice> GetInvoiceById(int id);
        Task<string> GetInvoiceNo();
        Task<IEnumerable<billing.Data.Models.Invoice>> GetInvoices(int customerId);
        Task<IEnumerable<ProductSaleReportDTO>> GetProductSale();
    }
}
