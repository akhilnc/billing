using AutoMapper;
using billing.Data.DTOs.Masters;
using billing.Data.Generics;
using billing.Data.Generics.General;
using billing.Data.Models;
using billing.Data.Repositories.Masters.Company;
using billing.Data.Resources;
using billing.Data.Resources.Labels;
using billing.Data.Resources.Validations;
using billing.Infrastructure.Common.Logger;
using billing.Infrastructure.Common.Utlilities.TokenUserClaims;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billing.Service.Masters.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepo _repo;
        private readonly IAppLogger _logger;
        private readonly UserBase _user;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyService"/> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <param name="claims">The claims.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CompanyService(ICompanyRepo repo, ITokenUserClaims claims, IMapper mapper, IAppLogger logger)
        {
            _user = claims.GetClaims();
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
        }


        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CompanyDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<CompanySettings>, IEnumerable<CompanyDTO>>(await _repo.GetAllAsync());
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="uId">The u identifier.</param>
        /// <returns></returns>
        public async Task<CompanyDTO> GetById(string uId)
        {
            var item = await _repo.GetCompanyByUId(uId);
            return _mapper.Map<CompanySettings, CompanyDTO>(item);
        }

        /// <summary>
        /// Gets the name of the by.
        /// </summary>
        /// <param name="companyName">Name of the company.</param>
        /// <returns></returns>
        public async Task<CompanyDTO> GetByName(string companyName)
        {
            var item = await _repo.GetCompanyByName(companyName);
            return _mapper.Map<CompanySettings, CompanyDTO>(item);
        }


        /// <summary>
        /// Saves the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public async Task<Envelope<int>> Save(CompanyDTO input)
        {
            try
            {
                var mappedInput = _mapper.Map<CompanyDTO, CompanySettings>(input);
                mappedInput.UId = Guid.NewGuid().ToString();
                mappedInput.CreatedBy = _user.UserGuid;
                mappedInput.ModifiedBy = _user.UserGuid;
                await _repo.AddAsync(mappedInput);
                var count = await _repo.CommitAsync();
                return count > 0
                    ? new Envelope<int>(true, mappedInput.Id, DbMessages.CREATED_SUCCESS)
                    : new Envelope<int>(false, 0, CommonMessages.SOMETHING_WRONG);
            }
            catch (Exception e)
            {

                await _logger.Error("Something went wrong", e);
                return new Envelope<int>(false, 0, CommonMessages.SOMETHING_WRONG);
            }
        }
        /// <summary>
        /// Updates the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public async Task<Envelope> Update(CompanyDTO input)
        {
            try
            {
                var mappedInput = _mapper.Map<CompanyDTO, CompanySettings>(input);
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


        public async Task<Envelope> Delete(string uId)
        {
            try
            {
                var item = await _repo.GetCompanyByUId(uId);
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
        /// <summary>
        /// Checks the duplication.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
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
