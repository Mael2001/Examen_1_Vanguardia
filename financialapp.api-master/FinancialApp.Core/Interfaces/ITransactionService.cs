using System;
using System.Collections.Generic;
using System.Text;
using FinancialApp.Core.Entities;

namespace FinancialApp.Core.Interfaces
{
    public interface ITransactionService
    {
        ServiceResult<IReadOnlyList<Transaction>> GetTransactions();
        ServiceResult<double> GetIncomes();
        ServiceResult<double> GetExpenses();
        ServiceResult<double> GetTotal();
        ServiceResult<Transaction> CreateTransaction(Transaction entity);
    }
}
