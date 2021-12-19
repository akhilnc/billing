
using billing.API.Validators;
using billing.Data;
using billing.Data.DTOs.Masters;
using billing.Data.Generics;
using billing.Data.Generics.General;
using billing.Service.Masters.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace billing.API.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="logger">The logger.</param>
        public UserController(IUserService service, ILogger<UserController> logger )
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
        [ProducesResponseType(typeof(UserDTO), 200)]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(GetAll), nameof(UserController));
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
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(GetById), nameof(UserController));
            return Ok(await _service.GetById(uId));
        }

        /// <summary>
        /// Saves the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Envelope), 200)]
        public async Task<IActionResult> Save([FromBody] UserDTO input)
        {
            var validator = new UserValidator(_service);
            var validationResult = await validator.ValidateAsync(input);

            if (!validationResult.IsValid)
                return Ok(new Envelope(false, validationResult.Errors.FirstOrDefault().ErrorMessage));
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(Save), nameof(UserController));
            return Ok(await _service.Save(input));
        }

        /// <summary>
        /// Updates the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Envelope), 200)]
        public async Task<IActionResult> Update([FromBody] UserDTO input)
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
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(CheckDuplication), nameof(UserController));
            return Ok(await _service.CheckDuplication(input));
        }

        #endregion
        #endregion
    }
}
