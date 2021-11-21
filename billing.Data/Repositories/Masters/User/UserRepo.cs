﻿using billing.Data.DbContexts;
using billing.Data.Generics.General;
using billing.Data.Models;
using billing.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace billing.Data.Repositories.Masters.User
{
    public class UserRepo: RepositoryBase<MstUser>,IUserRepo
    {
        private readonly LAppContext _appContext;

        public UserRepo(LAppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }

        #region Validations
        public async Task<bool> CheckDuplication(DuplicateValidation input)
        {
            var query =
                $"SELECT * FROM mst_user WHERE  {input.ColumnName} = '{input.Value}' AND {input.IdentifierColumnName} <> '{input.Identifier}' ";
            var result = await _appContext.MstUser.FromSqlRaw(query).ToListAsync();
            return result.Count==0;
        }
        #endregion
    }
}
