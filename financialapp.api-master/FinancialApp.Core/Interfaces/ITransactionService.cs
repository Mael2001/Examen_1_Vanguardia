using System;
using System.Collections.Generic;
using System.Text;
using FinancialApp.Core.Entities;

namespace FinancialApp.Core.Interfaces
{
    interface ITransactionService
    {
        ServiceResult<IReadOnlyList<Transaction>> GetTransactions();
        ServiceResult<double> GetIncomesById(int id);
        ServiceResult<double> GetExpensesById(int id);
        ServiceResult<double> GetTotalById(int id);
        ServiceResult<Transaction> CreateTransaction(Transaction entity);
    }
}
