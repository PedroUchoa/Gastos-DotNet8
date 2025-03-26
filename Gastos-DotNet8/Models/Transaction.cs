using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gastos_DotNet8.Models
{
    public class Transaction
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        [JsonIgnore]
        public Person Person { get; set; }
    }
}
