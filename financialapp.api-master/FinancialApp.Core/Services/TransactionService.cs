using System;
using System.Collections.Generic;
using System.Linq;
using FinancialApp.Core.Entities;
using FinancialApp.Core.Interfaces;

namespace FinancialApp.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<Transaction> _transactionRepository;

        public TransactionService(IRepository<Transaction> transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public ServiceResult<IReadOnlyList<Transaction>> GetTransactions()
        {
            var transactions = _transactionRepository.Get();
            IEnumerable<Transaction> lastTransactions = transactions.TakeLast(5);
            IReadOnlyList<Transaction> transactionsList = lastTransactions.ToList();
            return ServiceResult<IReadOnlyList<Transaction>>.SuccessResult(transactionsList);
        }

        public ServiceResult<double> GetIncomesById(int id)
        {
            var transactions = _transactionRepository
                .Filter(x => x.AccountId == id)
                .Where(x => x.Amount > 0)
                .ToList();


            if (transactions == null)
            {
                return ServiceResult<double>.NotFoundResult($"No se encontró una cuenta con el id {id}");
            }
            return ServiceResult<double>.SuccessResult(transactions.Sum(X=> Convert.ToInt32(X)));
        }

        public ServiceResult<double> GetExpensesById(int id)
        {
            var transactions = _transactionRepository
                .Filter(x => x.AccountId == id)
                .Where(x => x.Amount < 0)
                .ToList();

            if (transactions == null)
            {
                return ServiceResult<double>.NotFoundResult($"No se encontró una cuenta con el id {id}");
            }
            int expenses = transactions.Sum(X => Convert.ToInt32(X));
            return ServiceResult<double>.SuccessResult(expenses);

        }

        public ServiceResult<Double> GetTotalById(int id)
        {
            var transactionsIncome = _transactionRepository
                .Filter(x => x.AccountId == id)
                .Where(x => x.Amount > 0).ToList();
            var transactionsExpenses = _transactionRepository
                .Filter(x => x.AccountId == id)
                .Where(x => x.Amount < 0).ToList();

            if (transactionsIncome == null)
            {
                return ServiceResult<double>.NotFoundResult($"No se encontró una cuenta con el id {id}");
            }
            int expenses = transactionsExpenses.Sum(X => Convert.ToInt32(X));
            int incomes = transactionsIncome.Sum(X => Convert.ToInt32(X));

            return ServiceResult<double>.SuccessResult(incomes - expenses);
        }

        public ServiceResult<Transaction> CreateTransaction(Transaction entity)
        {
            var transaction = _transactionRepository.Get( entity.Id);
            if (transaction == null)
            {
                return ServiceResult<Transaction>.ErrorResult($"Ya existe un post con el id {entity.Id}");
            }

            _transactionRepository.Create(transaction);

            return ServiceResult<Transaction>.SuccessResult(transaction);
        }
    }
}