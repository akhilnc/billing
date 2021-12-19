using billing.Data.DTOs.Masters;
using billing.Data.Generics;
using billing.Data.Generics.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace billing.Service.Masters.User
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetById(string uId);
        Task<Envelope> Save(UserDTO input);
        Task<Envelope> Update(UserDTO input);
        Task<Envelope> Delete(string uId);
        Task<Envelope> CheckDuplication(DuplicateValidation input);
        Task<(bool, int, string)> IsUserActive(string userId, string userRole);

    }
}
