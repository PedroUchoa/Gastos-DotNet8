namespace Gastos_DotNet8.Dtos.Transaction
{
    public class TotalTransactionValueDto
    {

        public string Name { get; set; }
        public int TotalIncome { get; set; }
        public int TotalExpend { get; set;}
        public int Total {  get; set; }

        public TotalTransactionValueDto(string name,int TotalIncome,int TotalExpend,int Total)
        {
            this.Name = name;
            this.TotalIncome = TotalIncome;
            this.TotalExpend = TotalExpend;
            this.Total = Total;
        }

    }
}
