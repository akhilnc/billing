using AutoMapper;
using billing.Data.DTOs.Masters;
using billing.Data.Generics;
using billing.Data.Generics.General;
using billing.Data.Models;
using billing.Data.Repositories.Masters.Service;
using billing.Data.Resources;
using billing.Data.Resources.Labels;
using billing.Data.Resources.Validations;
using billing.Infrastructure.Common.Logger;
using billing.Infrastructure.Common.Utlilities.TokenUserClaims;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billing.Service.Masters.Service
{
    public class ServiceService:IServiceService
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepo _repo;
        private readonly IAppLogger _logger;
        private readonly UserBase _user;


        public ServiceService(IServiceRepo repo, ITokenUserClaims claims, IMapper mapper,IAppLogger logger)
        {
            _user = claims.GetClaims();
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
        }


        public async Task<IEnumerable<ServiceDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<MstService>, IEnumerable<ServiceDTO>>(await _repo.GetAllAsync());
        }
        public async Task<ServiceDTO> GetById(string uId)
        {
            return _mapper.Map<MstService, ServiceDTO>(await _repo.GetByIdAsync(uId));
        }

        public async Task<Envelope> Save(ServiceDTO input)
        {
            try
            {
                var mappedInput = _mapper.Map<ServiceDTO, MstService>(input);

                mappedInput.CreatedBy = _user.UserGuid;
                mappedInput.ModifiedBy = _user.UserGuid;
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
        public async Task<Envelope> Update(ServiceDTO input)
        {
            try
            {
                var mappedInput = _mapper.Map<ServiceDTO, MstService>(input);
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


        public async Task<Envelope> Delete(string sId)
        {
            try
            {
                var item = await _repo.GetByIdAsync(sId);
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
