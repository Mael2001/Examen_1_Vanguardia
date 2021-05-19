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
        private readonly IRepository<Account> _accountRepository;

        public TransactionService(IRepository<Transaction> transactionRepository,
            IRepository<Account> accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }
        public ServiceResult<IReadOnlyList<Transaction>> GetTransactions()
        {
            var transactions = _transactionRepository.Get();
            IEnumerable<Transaction> lastTransactions = transactions.TakeLast(5);
            IReadOnlyList<Transaction> transactionsList = lastTransactions.ToList();
            return ServiceResult<IReadOnlyList<Transaction>>.SuccessResult(transactionsList);
        }

        public ServiceResult<double> GetIncomes()
        {
            var transactions = _transactionRepository
                .Get()
                .Where(x => x.Amount > 0)
                .ToList();
            double incomes = 0;
            foreach (Transaction transaction in transactions)
            {
                incomes+= _accountRepository.Get(transaction.AccountId).ConversionRate * transaction.Amount;
            }

            return ServiceResult<double>.SuccessResult(incomes);
        }

        public ServiceResult<double> GetExpenses()
        {
            var transactions = _transactionRepository
                .Get()
                .Where(x => x.Amount < 0)
                .ToList();

            double expenses = 0;
            foreach (Transaction transaction in transactions)
            {
                expenses += _accountRepository.Get(transaction.AccountId).ConversionRate * transaction.Amount;
            }
            return ServiceResult<double>.SuccessResult(expenses);

        }

        public ServiceResult<double> GetTotal()
        {
            double expenses = GetExpenses().Result;
            double incomes = GetIncomes().Result;

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