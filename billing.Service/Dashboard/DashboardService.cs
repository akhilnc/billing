using AutoMapper;
using billing.Data.DTOs.Billing.Invoice;
using billing.Data.DTOs.Dashboard;
using billing.Data.DTOs.Masters;
using billing.Data.Repositories.Dashboard;
using billing.Infrastructure.Common.Logger;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace billing.Service.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly IMapper _mapper;
        private readonly IDashboardRepo _repo;
        private readonly IAppLogger _logger;


        public DashboardService(IDashboardRepo repo, IMapper mapper, IAppLogger logger)
        {
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
        }
        public async Task<DashboardDTO> GetDashboardData()
        {
            return await _repo.GetDashboardData();
        }

        public async Task<IEnumerable<InvoiceListDTO>> GetRecentInvoices()
        {
            return  _mapper.Map<IEnumerable<billing.Data.Models.Invoice>, IEnumerable<InvoiceListDTO>>(await _repo.GetRecentInvoices());
        }
    }
}
