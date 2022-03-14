using billing.Data.DTOs.Billing.Invoice;
using billing.Data.DTOs.Masters;
using billing.Data.Generics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace billing.Service.Billing.Invoice
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceListDTO>> GetAll();
        Task<InvoiceDTO> GetInvoiceById(int id);
        Task<Envelope<int>> Save(InvoiceDTO input);
        Task<Envelope<int>> Update(InvoiceDTO input);
        Task<Envelope> Delete(int id);
        Task<string> GetInvoiceNo();
        Task<IEnumerable<InvoiceDTO>> GetInvoices(int customerId);
        Task<IEnumerable<ProductSaleReportDTO>> GetProductSale(DateTime from, DateTime to);
        Task<decimal> GetMonthlyServiceCharge(DateTime from, DateTime to);
    }
}
