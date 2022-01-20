using billing.Data;
using billing.Data.DTOs.Masters;
using billing.Data.Generics;
using billing.Service.Billing.Invoice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing.API.Controllers.Billing
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _service;
        private readonly ILogger<InvoiceController> _logger;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceController" /> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="logger">The logger.</param>
        public InvoiceController(IInvoiceService service, ILogger<InvoiceController> logger)
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
        [ProducesResponseType(typeof(InvoiceDTO), 200)]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(GetAll), nameof(InvoiceController));
            return Ok(await _service.GetAll());
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="uId">The u identifier.</param>
        /// <returns></returns>
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(InvoiceDTO), 200)]
        public async Task<IActionResult> GetById(string uId)
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(GetById), nameof(InvoiceController));
            return Ok(await _service.GetById(uId));
        }

        /// <summary>
        /// Saves the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Envelope), 200)]
        public async Task<IActionResult> Save([FromBody] InvoiceDTO input)
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(Save), nameof(InvoiceController));
            return Ok(await _service.Save(input));
        }

        /// <summary>
        /// Updates the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Envelope), 200)]
        public async Task<IActionResult> Update([FromBody] InvoiceDTO input)
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(Update), nameof(InvoiceController));
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
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(Delete), nameof(InvoiceController));
            return Ok(await _service.Delete(uId));
        }

        /// <summary>
        /// Get invoice no.
        /// </summary>
        /// <param name="uId">The u identifier.</param>
        /// <returns></returns>
        [HttpGet("GetInvoiceNo")]
        [ProducesResponseType(typeof(JsonResult), 200)]
        public async Task<IActionResult> GetInvoiceNo()
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(GetInvoiceNo), nameof(InvoiceController));
            return Ok(await _service.GetInvoiceNo());
        }

        #endregion
    }
}
