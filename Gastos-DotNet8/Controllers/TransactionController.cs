using Gastos_DotNet8.Dtos.Person;
using Gastos_DotNet8.Dtos.Transaction;
using Gastos_DotNet8.Models;
using Gastos_DotNet8.Services.Person;
using Gastos_DotNet8.Services.Transaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Gastos_DotNet8.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly ITransactionInterface _transactionInterface;

        public TransactionController(ITransactionInterface transactionInterface)
        {
            _transactionInterface = transactionInterface;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<TransactionModel>>> CreatePerson(CreateTransactionDto createTransaction)
        {
            var returnedTransaction = await _transactionInterface.CreateTransaction(createTransaction);
            return Ok(returnedTransaction);

        }

        [HttpGet("{idTransaction}")]
        public async Task<ActionResult<ResponseModel<ReturnTransactionDto>>> GetTransactionById(int idTransaction)
        {
            var transaction = await _transactionInterface.GetTransactionById(idTransaction);
            return Ok(transaction);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<ReturnTransactionDto>>>> ListAllTransactions()
        {
            var transactions = await _transactionInterface.ListAllTransactions();
            return Ok(transactions);
        }

        [HttpGet("Total")]
        public async Task<ActionResult<ResponseModel<List<TotalTransactionValueDto>>>> ListValueAllTransactions()
        {
            var transactions = await _transactionInterface.ValueTotalTransactions();
            return Ok(transactions);
        }

    }
}
