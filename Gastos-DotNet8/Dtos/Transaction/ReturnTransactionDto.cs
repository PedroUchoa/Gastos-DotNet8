using Gastos_DotNet8.Models;

namespace Gastos_DotNet8.Dtos.Transaction
{
    public class ReturnTransactionDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public TransactionType transactionType { get; set; }
        public string PersonName { get; set; }

    }
}
