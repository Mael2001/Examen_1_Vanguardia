using System;
using System.Collections.Generic;
using System.Text;
using FinancialApp.Core.Entities;

namespace FinancialApp.Core.Interfaces
{
    interface IAccountService
    {
        ServiceResult<IReadOnlyList<Account>> GetAccounts();
        ServiceResult<Account> GetAccountById(long id);
    }
}
