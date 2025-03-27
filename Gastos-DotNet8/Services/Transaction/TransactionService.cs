using System.Diagnostics;
using Gastos_DotNet8.Data;
using Gastos_DotNet8.Dtos.Transaction;
using Gastos_DotNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace Gastos_DotNet8.Services.Transaction
{
    public class TransactionService : ITransactionInterface
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<TransactionModel>> CreateTransaction(CreateTransactionDto createTransactionDto)
        {
            ResponseModel<TransactionModel> response = new ResponseModel<TransactionModel>();
            try
            {
                var person = await _context.Persons.FirstOrDefaultAsync(personDb => personDb.Id == createTransactionDto.PersonId);

                if (person == null) 
                {
                    response.Mensagem = "Person With The id: " + createTransactionDto.PersonId + " Not Found";
                    response.Data = new TransactionModel();
                    return response;
                }

                var transaction = new TransactionModel()
                {
                    Description = createTransactionDto.Description,
                    Value = createTransactionDto.Value,
                    TransactionType = createTransactionDto.TransactionType,
                    Person = person,
                };
            
                var newTrasaction = _context.Add(transaction);
                await _context.SaveChangesAsync();

                response.Data = newTrasaction.Entity;
                return response;
                }
            catch (Exception ex) 
            { 
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<ReturnTransactionDto>> GetTransactionById(int id)
        {
            ResponseModel<ReturnTransactionDto> response = new ResponseModel<ReturnTransactionDto>();
            try
            {

                var transaction = await _context.Transactions.Include(p => p.Person).FirstOrDefaultAsync(transactionDb => transactionDb.Id == id);

                if (transaction == null)
                {
                    response.Mensagem = "Person Not Found in the DataBase";
                    return response;
                }

                response.Data = new ReturnTransactionDto()
                {
                    Id = transaction.Id,
                    Description = transaction.Description,
                    PersonName = transaction.Person.Name,
                    transactionType = transaction.TransactionType,
                    Value = transaction.Value,
                };
                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<ReturnTransactionDto>>> ListAllTransactions()
        {
            ResponseModel<List<ReturnTransactionDto>> response = new ResponseModel<List<ReturnTransactionDto>>();
            try
            {
                var transactions = await _context.Transactions.Include(p => p.Person).ToListAsync();
                List<ReturnTransactionDto> returnTransactionDtos = new List<ReturnTransactionDto>();

                foreach (var item in transactions)
                {
                    var returnedTransaction = new ReturnTransactionDto()
                    {
                        Id= item.Id,
                        Description = item.Description,
                        PersonName= item.Person.Name,
                        transactionType = item.TransactionType,
                        Value = item.Value,
                    };
                    returnTransactionDtos.Add(returnedTransaction);
                }
                response.Data = returnTransactionDtos;
                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<TotalTransactionValueDto>>> ValueTotalTransactions()
        {
            ResponseModel<List<TotalTransactionValueDto>> response = new ResponseModel<List<TotalTransactionValueDto>>();
            try
            {
                var persons = await _context.Persons.Include(t => t.Transactions).ToListAsync();
                List<TotalTransactionValueDto> returnTransactionDtos = new List<TotalTransactionValueDto>();

                foreach (var item in persons)
                {
                    returnTransactionDtos.Add(item.TotalTransaction());   
                }
                response.Data = returnTransactionDtos;
                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
