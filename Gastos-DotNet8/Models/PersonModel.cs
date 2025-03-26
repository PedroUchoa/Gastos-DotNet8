using System.Text.Json.Serialization;

namespace Gastos_DotNet8.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<TransactionModel> Transactions { get; set; } = new List<TransactionModel>();
    }
}
