using System;
using System.Collections.Generic;
using System.Linq;
using FinancialApp.Core.Entities;

namespace FinancialApp.Data.Repositories
{
    public class AccountRepository: BaseRepository<Account>
    {
        private readonly FinancialAppContext _financialAppContext;

        public AccountRepository(FinancialAppContext financialAppContext) : base(financialAppContext)
        {
            _financialAppContext = financialAppContext;
        }

        public override IReadOnlyList<Account> Get()
        {
            return _financialAppContext.Account.ToList();
        }

        public override Account Get(long id)
        {
            return _financialAppContext.Account.FirstOrDefault(x => x.Id == id);
        }

        public override IReadOnlyList<Account> Filter(Func<Account, bool> predicate)
        {
            return _financialAppContext.Account.Where(predicate).ToList();
        }
    }
}