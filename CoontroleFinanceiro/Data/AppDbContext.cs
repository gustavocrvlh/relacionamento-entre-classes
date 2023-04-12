using CoontroleFinanceiro.Model;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

using static System.Console;

namespace CoontroleFinanceiro.Data
{
    internal class AppDbContext : DbContext
    {

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Banco> Bancos { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder
                optionsBuilder)
                => optionsBuilder
                .UseSqlServer("Data Source=DESKTOP-410ALKE\\sqlexpress;Initial" +
                    " Catalog=EFCore5DB; Integrated Security=true")
                .LogTo(WriteLine, new[] { RelationalEventId.CommandExecuted })
                .EnableSensitiveDataLogging();
        
    }
}
