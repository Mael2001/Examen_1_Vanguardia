using System;
using System.Collections.Generic;
using System.Text;
using FinancialApp.Core.Entities;
using FinancialApp.Core.Interfaces;

namespace FinancialApp.Core.Services
{
    public class AccountService:IAccountService
    {
        private readonly IRepository<Account> _accountRepository;

        public AccountService(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public ServiceResult<IReadOnlyList<Account>> GetAccounts()
        {
            var accounts = _accountRepository.Get();
            return ServiceResult<IReadOnlyList<Account>>.SuccessResult(accounts);
        }

        public ServiceResult<Account> GetAccountById(long id)
        {
            var account = _accountRepository.Get(id);
            if (account == null)
            {
                return ServiceResult<Account>.NotFoundResult($"No se encontró una cuenta con el id {id}");
            }

            return ServiceResult<Account>.SuccessResult(account);
        }
    }
}
