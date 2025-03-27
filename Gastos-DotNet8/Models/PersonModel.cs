using System.Text.Json.Serialization;
using Gastos_DotNet8.Dtos.Transaction;

namespace Gastos_DotNet8.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<TransactionModel> Transactions { get; set; }
        public TotalTransactionValueDto TotalTransaction()
        {
            int TotalIncome = 0;
            int TotalExpend = 0;
            foreach (var item in Transactions)
            {
                if(item.TransactionType == TransactionType.Income) TotalIncome += item.Value;
                if(item.TransactionType == TransactionType.Expense) TotalExpend += item.Value;
            }
            int Total = TotalIncome - TotalExpend;
            return new TotalTransactionValueDto(this.Name, TotalIncome, TotalExpend, Total);
        }
    }

}