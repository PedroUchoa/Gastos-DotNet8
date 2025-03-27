using Gastos_DotNet8.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gastos_DotNet8.Dtos.Transaction
{
    public class CreateTransactionDto
    {
        public string Description { get; set; }
        public int Value { get; set; }
        public TransactionType TransactionType { get; set; }
        public required int PersonId { get; set; }

    }
}
