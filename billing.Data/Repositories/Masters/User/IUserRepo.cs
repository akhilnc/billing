using billing.Data.Generics.General;
using billing.Data.Models;
using billing.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace billing.Data.Repositories.Masters.User
{
    public interface IUserRepo : IRepositoryBase<MstUser>
    {
        Task<bool> CheckDuplication(DuplicateValidation input);
    }
}
