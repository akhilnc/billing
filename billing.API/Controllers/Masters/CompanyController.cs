using billing.API.Validators;
using billing.Data;
using billing.Data.DTOs.Masters;
using billing.Data.Generics;
using billing.Data.Generics.General;
using billing.Service.Masters.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace billing.API.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _service;
        private readonly ILogger<CompanyController> _logger;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyController" /> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="logger">The logger.</param>
        public CompanyController(ICompanyService service, ILogger<CompanyController> logger)
        {
            _service = service;
            _logger = logger;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(CompanyDTO), 200)]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(GetAll), nameof(CompanyController));
            return Ok(await _service.GetAll());
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="uId">The u identifier.</param>
        /// <returns></returns>
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(CompanyDTO), 200)]
        public async Task<IActionResult> GetById(string uId)
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(GetById), nameof(CompanyController));
            return Ok(await _service.GetById(uId));
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="companyName">The u identifier.</param>
        /// <returns></returns>
        [HttpGet("GetByName")]
        [ProducesResponseType(typeof(CompanyDTO), 200)]
        public async Task<IActionResult> GetByName(string companyName)
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(GetByName), nameof(CompanyController));
            return Ok(await _service.GetByName(companyName));
        }

        /// <summary>
        /// Saves the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Envelope), 200)]
        public async Task<IActionResult> Save([FromBody] CompanyDTO input)
        {
            var validator = new CompanyValidator(_service);
            var validationResult = await validator.ValidateAsync(input);

            if (!validationResult.IsValid)
                return Ok(new Envelope(false, validationResult.Errors.FirstOrDefault().ErrorMessage));
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(Save), nameof(CompanyController));
            return Ok(await _service.Save(input));
        }

        /// <summary>
        /// Updates the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Envelope), 200)]
        public async Task<IActionResult> Update([FromBody] CompanyDTO input)
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(Update), nameof(CompanyController));
            return Ok(await _service.Update(input));
        }

        /// <summary>
        /// Deletes the specified u identifier.
        /// </summary>
        /// <param name="uId">The u identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(Envelope), 200)]
        public async Task<IActionResult> Delete(string uId)
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(Delete), nameof(CustomerController));
            return Ok(await _service.Delete(uId));
        }

        #region Validation

        /// <summary>
        /// Checks the duplication.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpGet("CheckDuplication")]
        public async Task<IActionResult> CheckDuplication([FromQuery] DuplicateValidation input)
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(CheckDuplication), nameof(CompanyController));
            return Ok(await _service.CheckDuplication(input));
        }

        #endregion

        #endregion
    }
}
