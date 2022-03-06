using billing.API.Validators;
using billing.Data;
using billing.Data.DTOs.Dropdown;
using billing.Data.DTOs.Masters;
using billing.Data.Generics;
using billing.Data.Generics.General;
using billing.Service.Masters.Service;
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
    public class ServiceController : ControllerBase
    {
        private readonly ILogger<ServiceController> _logger;
        private readonly IServiceService _service;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceController" /> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="logger">The logger.</param>
        public ServiceController(IServiceService service, ILogger<ServiceController> logger)
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
        [ProducesResponseType(typeof(ServiceDTO), 200)]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(GetAll), nameof(ServiceController));
            return Ok(await _service.GetAll());
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="uId">The u identifier.</param>
        /// <returns></returns>
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(UserDTO), 200)]
        public async Task<IActionResult> GetById(string uId)
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(GetById), nameof(ServiceController));
            return Ok(await _service.GetById(uId));
        }

        /// <summary>
        /// Saves the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Envelope), 200)]

        public async Task<IActionResult> Save([FromBody] ServiceDTO input)
        {
            var validator = new ServiceValidator(_service);
            var validationResult = await validator.ValidateAsync(input);

            if (!validationResult.IsValid)
                return Ok(new Envelope(false, validationResult.Errors.FirstOrDefault().ErrorMessage));
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(Save), nameof(ServiceController));
            return Ok(await _service.Save(input));
        }

        /// <summary>
        /// Updates the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Envelope), 200)]
        public async Task<IActionResult> Update([FromBody] ServiceDTO input)
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(Update), nameof(UserController));
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
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(Delete), nameof(UserController));
            if (_service.IsProductExits(uId))
            {
                return Ok(new Envelope(false, ApplicationConstants.ProductIsalreadyInuse));
            }
            return Ok(await _service.Delete(uId));
        }
        /// <summary>
        /// Gets service dropdown.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetServiceDropdown")]
        [ProducesResponseType(typeof(ServiceDropdownDTO), 200)]
        public async Task<IActionResult> GetServiceDropdown()
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(GetServiceDropdown), nameof(CustomerController));
            return Ok(await _service.GetServiceDropdown());
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
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(CheckDuplication), nameof(UserController));
            return Ok(await _service.CheckDuplication(input));
        }

        #endregion
        #endregion


    }
}
