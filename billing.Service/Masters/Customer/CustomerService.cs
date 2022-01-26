using AutoMapper;
using billing.Data.DTOs.Dropdown;
using billing.Data.DTOs.Masters;
using billing.Data.Generics;
using billing.Data.Generics.General;
using billing.Data.Models;
using billing.Data.Repositories.Masters.Customer;
using billing.Data.Resources;
using billing.Data.Resources.Labels;
using billing.Data.Resources.Validations;
using billing.Infrastructure.Common.Logger;
using billing.Infrastructure.Common.Utlilities.TokenUserClaims;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billing.Service.Masters.Customer
{
   public  class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepo _repo;
        private readonly IAppLogger _logger;
        private readonly UserBase _user;


        public CustomerService(ICustomerRepo repo, ITokenUserClaims claims, IMapper mapper, IAppLogger logger)
        {
            _user = claims.GetClaims();
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
        }


        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<MstCustomer>, IEnumerable<CustomerDTO>>(await _repo.GetAllAsync());
        }
        public async Task<CustomerDTO> GetById(string uId)
        {
            var item = await _repo.GetCustomerByUId(uId);
            return _mapper.Map<MstCustomer, CustomerDTO>(item);
        }

        public async Task<Envelope<int>> Save(CustomerDTO input)
        {
            try
            {
                var mappedInput = _mapper.Map<CustomerDTO, MstCustomer>(input);
                mappedInput.UId = Guid.NewGuid().ToString();
                await _repo.AddAsync(mappedInput);
                var count = await _repo.CommitAsync();
                return count > 0
                    ? new Envelope<int>(true,mappedInput.Id,DbMessages.CREATED_SUCCESS)
                    : new Envelope<int>(false,0, CommonMessages.SOMETHING_WRONG);
            }
            catch (Exception e)
            {

                await _logger.Error("Something went wrong", e);
                return new Envelope<int>(false,0, CommonMessages.SOMETHING_WRONG);
            }
        }
        public async Task<Envelope> Update(CustomerDTO input)
        {
            try
            {
                var mappedInput = _mapper.Map<CustomerDTO, MstCustomer>(input);
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


        /// <summary>
        /// Deletes the specified s identifier.
        /// </summary>
        /// <param name="uId">The s identifier.</param>
        /// <returns></returns>
        public async Task<Envelope> Delete(string uId)
        {
            try
            {
                var item = await _repo.GetCustomerByUId(uId);
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
        public async Task<IEnumerable<CustomerDropdownDTO>> GetCustomerDropdown()
        {
            return await _repo.GetCustomerDropdown();
        }
        #region Validations
        public async Task<Envelope> CheckDuplication(DuplicateValidation input)
        {
            try
            {
                return
                    await _repo.CheckDuplication(input) ?
                    new Envelope(true, CommonValidationMessages.CUSTOM_VALUE_DUPLICATION.Replace("{{Label}}", CommonLabels.ResourceManager.GetString(input.Label)))
                    :
                    new Envelope(false, CommonMessages.NO_DUPLICATION);
            }
            catch (Exception e)
            {
                return new Envelope(false, CommonMessages.SOMETHING_WRONG);
            }
        }


        #endregion
    }
}
