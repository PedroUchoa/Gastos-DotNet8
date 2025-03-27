using Gastos_DotNet8.Dtos.Person;
using Gastos_DotNet8.Dtos.Transaction;
using Gastos_DotNet8.Models;

namespace Gastos_DotNet8.Services.Transaction
{
    public interface ITransactionInterface
    {
       Task<ResponseModel<TransactionModel>> CreateTransaction(CreateTransactionDto createTransactionDto);
       Task<ResponseModel<List<ReturnTransactionDto>>> ListAllTransactions();
       Task<ResponseModel<ReturnTransactionDto>> GetTransactionById(int id);
       Task<ResponseModel<List<TotalTransactionValueDto>>> ValueTotalTransactions();


    }
}
