using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gastos_DotNet8.Models
{
    public class TransactionModel
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }

        [Column(TypeName ="nvarchar(24)")]
        public TransactionType TransactionType { get; set; }

        [JsonIgnore]
        public PersonModel Person { get; set; }
    }
}
