using AutoMapper;
using billing.Data.DTOs.Masters;
using billing.Data.Generics;
using billing.Data.Generics.General;
using billing.Data.Repositories.Billing.Invoice;
using billing.Data.Resources;
using billing.Infrastructure.Common.Logger;
using billing.Infrastructure.Common.Utlilities.TokenUserClaims;
using billing.Service.Billing.Invoice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace billing.Invoice.Billing.Invoice
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepo _repo;
        private readonly IAppLogger _logger;
        private readonly UserBase _user;


        public InvoiceService(IInvoiceRepo repo, ITokenUserClaims claims, IMapper mapper, IAppLogger logger)
        {
            _user = claims.GetClaims();
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
        }


        public async Task<IEnumerable<InvoiceDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<billing.Data.Models.Invoice>, IEnumerable<InvoiceDTO>>(await _repo.GetAllAsync());
        }
        public async Task<InvoiceDTO> GetById(string id)
        {
            var item = await _repo.GetByIdAsync(id);
            return _mapper.Map<billing.Data.Models.Invoice, InvoiceDTO>(item);
        }

        public async Task<Envelope> Save(InvoiceDTO input)
        {
            try
            {
                var mappedInput = _mapper.Map<InvoiceDTO, billing.Data.Models.Invoice>(input);
                mappedInput.CreatedBy = _user.UserGuid;
                mappedInput.CreatedOn = DateTime.Now;
                await _repo.AddAsync(mappedInput);
                var count = await _repo.CommitAsync();
                return count > 0
                    ? new Envelope(true, DbMessages.CREATED_SUCCESS)
                    : new Envelope(false, CommonMessages.SOMETHING_WRONG);
            }
            catch (Exception e)
            {

                await _logger.Error("Something went wrong", e);
                return new Envelope(false, CommonMessages.SOMETHING_WRONG);
            }
        }
        public async Task<Envelope> Update(InvoiceDTO input)
        {
            try
            {
                var mappedInput = _mapper.Map<InvoiceDTO, billing.Data.Models.Invoice>(input);
                mappedInput.ModifiedBy = _user.UserGuid;
                await _repo.AddAsync(mappedInput);
                await _repo.UpdateAsync(mappedInput);
                var count = await _repo.CommitAsync();
                return count > 0
                    ? new Envelope(true, DbMessages.UPDATED_SUCCESS)
                    : new Envelope(false, CommonMessages.SOMETHING_WRONG);
            }
            catch (Exception e)
            {
                return new Envelope(false, CommonMessages.SOMETHING_WRONG);
            }
        }


        public async Task<Envelope> Delete(string id)
        {
            try
            {
                var item = await _repo.GetByIdAsync(id);
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

    }
}