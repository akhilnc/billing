using billing.Data;
using billing.Data.DTOs.Billing.Invoice;
using billing.Data.DTOs.Dashboard;
using billing.Service.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing.API.Controllers.Dashboard
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;
        private readonly ILogger<DashboardController> _logger;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardController" /> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="logger">The logger.</param>
        public DashboardController(IDashboardService service, ILogger<DashboardController> logger)
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
        [HttpGet("GetDashboardCount")]
        [ProducesResponseType(typeof(DashboardDTO), 200)]
        public async Task<IActionResult> GetDashboardData()
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(GetDashboardData), nameof(DashboardController));
            return Ok(await _service.GetDashboardData());
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRecentInvoices")]
        [ProducesResponseType(typeof(InvoiceListDTO), 200)]
        public async Task<IActionResult> GetRecentInvoices()
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(GetRecentInvoices), nameof(DashboardController));
            return Ok(await _service.GetRecentInvoices());
        }
        #endregion
    }
}
