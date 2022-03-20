using AutoMapper;
using billing.Data.DTOs.Billing.Invoice;
using billing.Data.DTOs.Masters;
using billing.Data.Generics;
using billing.Data.Generics.General;
using billing.Data.Repositories.Billing.Invoice;
using billing.Data.Resources;
using billing.Infrastructure.Common.Logger;
using billing.Infrastructure.Common.Utlilities.TokenUserClaims;
using billing.Service.Billing.Invoice;
using billing.Service.Masters.Customer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billing.Invoice.Billing.Invoice
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepo _repo;
        private readonly ICustomerService _cusService;
        private readonly IAppLogger _logger;
        private readonly UserBase _user;


        public InvoiceService(IInvoiceRepo repo, ITokenUserClaims claims, IMapper mapper, IAppLogger logger, ICustomerService cusService)
        {
            _user = claims.GetClaims();
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
            _cusService = cusService;
        }


        public async Task<IEnumerable<InvoiceListDTO>> GetAll()
        {
            var items = await _repo.GetAllInvoice();
            return _mapper.Map<IEnumerable<billing.Data.Models.Invoice>, IEnumerable<InvoiceListDTO>>(items);
        }
        public async Task<InvoiceDTO> GetInvoiceById(int id)
        {
            var item = await _repo.GetInvoiceById(id);
            return _mapper.Map<billing.Data.Models.Invoice, InvoiceDTO>(item);
        }

        public async Task<Envelope<int>> Save(InvoiceDTO input)
        {
            try
            {
                var mappedInput = _mapper.Map<InvoiceDTO, billing.Data.Models.Invoice>(input);
                if (input.Customer.Id == 0)
                {
                    var customer =await _cusService.Save(input.Customer);
                    if (customer.Success)
                    {
                        mappedInput.Customer.Id = customer.Data;
                    }
                    else
                    {
                        return new Envelope<int>(false,0, CommonMessages.SOMETHING_WRONG);
                    }
                }
                mappedInput.InvoiceDate = DateTime.Now;
                mappedInput.CustomerId = mappedInput.Customer.Id;
                mappedInput.Customer = null;
                mappedInput.CreatedBy = _user.UserGuid;
                mappedInput.CreatedOn = DateTime.Now;
                await _repo.AddAsync(mappedInput);
                var count = await _repo.CommitAsync();
                return count > 0
                    ? new Envelope<int>(true, mappedInput.Id, DbMessages.CREATED_SUCCESS)
                    : new Envelope<int>(false,0, CommonMessages.SOMETHING_WRONG);
            }
            catch (Exception e)
            {

                await _logger.Error("Something went wrong", e);
                return new Envelope<int>(false,0, CommonMessages.SOMETHING_WRONG);
            }
        }
        public async Task<Envelope<int>> Update(InvoiceDTO input)
        {
            try
            {
                var mappedInput = _mapper.Map<InvoiceDTO, billing.Data.Models.Invoice>(input);

                if (input.Customer.Id == 0)
                {
                    var customer = await _cusService.Save(input.Customer);
                    if (customer.Success)
                    {
                        mappedInput.Customer.Id = customer.Data;
                    }
                    else
                    {
                        return new Envelope<int>(false, 0, CommonMessages.SOMETHING_WRONG);
                    }
                }
                else
                {
                    var customer = await _cusService.Update(input.Customer);
                    if (customer.Success)
                    {
                        mappedInput.Customer.Id = customer.Data;
                    }
                    else
                    {
                        return new Envelope<int>(false, 0, CommonMessages.SOMETHING_WRONG);
                    }
                }
         
                foreach (var item in mappedInput.InvoiceItems)
                {
                    item.InvoiceId = mappedInput.Id;
                }
                mappedInput.CustomerId = mappedInput.Customer.Id;
                mappedInput.Customer = null;
                mappedInput.ModifiedBy = _user.UserGuid;
                mappedInput.ModifiedOn = DateTime.Now;
                await _repo.UpdateAsync(mappedInput);
                var count = await _repo.CommitAsync();
                return count > 0
                    ? new Envelope<int>(true, mappedInput.Id, DbMessages.CREATED_SUCCESS)
                    : new Envelope<int>(false, 0, CommonMessages.SOMETHING_WRONG);
            }
            catch (Exception e)
            {
                return new Envelope<int>(false,0, CommonMessages.SOMETHING_WRONG);
            }
        }


        public async Task<Envelope> Delete(int id)
        {
            try
            {
                var item = await _repo.GetInvoiceById(id);
                _repo.Remove(item);
                var count = await _repo.CommitAsync();
                return count > 0
                    ? new Envelope(true, DbMessages.DELETED_SUCCESS)
                    : new Envelope(false, CommonMessages.SOMETHING_WRONG);
            }
            catch (Exception e)
            {
                return new Envelope(false, CommonMessages.SOMETHING_WRONG);
            }
        }
        public async Task<string> GetInvoiceNo()
        {
            string lastInvoiceId= await _repo.GetInvoiceNo();
            int subDigits = 0;
            if (!string.IsNullOrEmpty(lastInvoiceId))
            {
                Int32.TryParse(lastInvoiceId.Substring(2), out subDigits);
            }
            lastInvoiceId = $"JC{subDigits + 1}";
            return lastInvoiceId;
        }

        public async Task<IEnumerable<InvoiceDTO>> GetInvoices(int customerId)
        {
            return _mapper.Map<IEnumerable<billing.Data.Models.Invoice>, IEnumerable<InvoiceDTO>>(await _repo.GetInvoices(customerId));
        }

        public async Task<IEnumerable<ProductSaleReportDTO>> GetProductSale(DateTime from, DateTime to)
        {
            return await _repo.GetProductSale(from,to);
        }
        public async Task<decimal> GetMonthlyServiceCharge(DateTime from, DateTime to)
        {
            return await _repo.GetMonthlyServiceCharge(from, to);
        }
    }
}