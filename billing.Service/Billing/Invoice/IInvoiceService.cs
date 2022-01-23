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
        Task<Envelope> Delete(string uId);
        Task<string> GetInvoiceNo();
    }
}
