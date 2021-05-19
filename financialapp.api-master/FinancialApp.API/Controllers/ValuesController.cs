using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialApp.API.Models;
using FinancialApp.Core;
using FinancialApp.Core.Entities;
using FinancialApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly TransactionService _transactionService;

        public ValuesController(AccountService accountService, TransactionService transactionService)
        {
            _accountService = accountService;
            _transactionService = transactionService;
        }
        // GET api/values
        [HttpGet("/accounts")]
        public ActionResult<IEnumerable<AccountDto>> GetAccounts()
        {
            var accounts = _accountService.GetAccounts()
                .Result
                .Select(x => new AccountDto
                {
                    Amount = x.Amount,
                    Name = x.Name
                });
            return Ok(accounts);
        }
        [HttpGet("/transactions")]
        public ActionResult<IEnumerable<TransactionDto>> GetTransactions()
        {
            var transactions = _transactionService.GetTransactions()
                .Result
                .Select(x => new TransactionDto
                {
                    TransactionDate = x.TransactionDate,
                    Amount = x.Amount,
                    Description = x.Description
                });
            return Ok(transactions);
        }

        // GET api/values/5
        [HttpGet("/summary/expenses/{id}")]
        public ActionResult<Double> GetExpenses(int id)
        {
            var account = _accountService.GetAccountById(id);
            var expenses = _transactionService.GetExpensesById(id);
            if (account.ResponseCode == ResponseCode.NotFound 
                || expenses.ResponseCode == ResponseCode.NotFound)
            {
                return BadRequest(account.Error);
            }
            
            return Ok(expenses.Result * account.Result.ConversionRate);
        }
        // GET api/values/5
        [HttpGet("/summary/incomes/{id}")]
        public ActionResult<Double> GetIncomes(int id)
        {
            var account = _accountService.GetAccountById(id);
            var incomes = _transactionService.GetIncomesById(id);
            if (account.ResponseCode == ResponseCode.NotFound
                || incomes.ResponseCode == ResponseCode.NotFound)
            {
                return BadRequest(account.Error);
            }
            return Ok(incomes.Result * account.Result.ConversionRate);
        }
        // GET api/values/5
        [HttpGet("/summary/total/{id}")]
        public ActionResult<Double> GetTotal(int id)
        {
            var account = _accountService.GetAccountById(id);
            var total = _transactionService.GetTotalById(id);
            if (account.ResponseCode == ResponseCode.NotFound
                || total.ResponseCode == ResponseCode.NotFound)
            {
                return BadRequest(account.Error);
            }
            return Ok(total.Result * account.Result.ConversionRate);
        }
        // POST api/values
        [HttpPost("/new/transaction")]
        public ActionResult<TransactionDto> Post([FromBody] TransactionDto transaction)
        {
            var transactionEntity = new Transaction
            {
                Amount = transaction.Amount,
                AccountId = transaction.AccountId,
                Description = transaction.Description,
                TransactionDate = transaction.TransactionDate
            };
            var result = _transactionService.CreateTransaction(transactionEntity);
            if (result.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(result.Error);
            }
            _accountService.GetAccountById(result.Result.AccountId).Result.Amount += result.Result.Amount;
            return Ok(result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
