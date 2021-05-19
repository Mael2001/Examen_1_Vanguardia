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
        [HttpGet("/summary/expenses")]
        public ActionResult<double> GetExpenses(int id)
        {
            var expenses = _transactionService.GetExpenses();
            if (expenses.ResponseCode == ResponseCode.NotFound)
            {
                return BadRequest(expenses.Error);
            }
            
            return Ok(expenses.Result);
        }
        // GET api/values/5
        [HttpGet("/summary/incomes")]
        public ActionResult<double> GetIncomes()
        {
            var incomes = _transactionService.GetIncomes();
            if (incomes.ResponseCode == ResponseCode.NotFound)
            {
                return BadRequest(incomes.Error);
            }
            return Ok(incomes.Result);
        }
        // GET api/values/5
        [HttpGet("/summary/total")]
        public ActionResult<double> GetTotal()
        {
            var total = _transactionService.GetTotal();
            if (total.ResponseCode == ResponseCode.NotFound)
            {
                return BadRequest(total.Error);
            }
            return Ok(total.Result);
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
