using System.Text.Json.Serialization;

namespace Gastos_DotNet8.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
