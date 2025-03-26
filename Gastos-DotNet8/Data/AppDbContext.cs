using Gastos_DotNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace Gastos_DotNet8.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }



        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<TransactionModel> Transactions { get; set; }

    }
}
