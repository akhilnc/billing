using billing.Data.DTOs.Masters;
using billing.Data.Generics;
using billing.Data.Generics.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billing.Service.Masters.Company
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDTO>> GetAll();
        Task<CompanyDTO> GetById(string uId);
        Task<Envelope<int>> Save(CompanyDTO input);
        Task<Envelope> Update(CompanyDTO input);
        Task<Envelope> Delete(string uId);
        Task<Envelope> CheckDuplication(DuplicateValidation input);
    }
}
