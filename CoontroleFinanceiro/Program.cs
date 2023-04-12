using CoontroleFinanceiro.Data;
using CoontroleFinanceiro.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;

namespace CoontroleFinanceiro
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await using var ctx = new AppDbContext();

            await ctx.Database.EnsureDeletedAsync();

            await ctx.Database.EnsureCreatedAsync();

            var gustavo = new Cliente { Nome = "Gustavo" };
            var gabriel = new Cliente { Nome = "Gabriel" };
            var pedro = new Cliente { Nome = "Pedro" };
            var maria = new Cliente { Nome = "Maria" };
            var perola = new Cliente { Nome = "Pérola" };


            var Santander = new Banco { Nome = "Santander", Clientes = new List<Cliente> { gustavo, gabriel, perola } };
            var Itau = new Banco { Nome = "Itau", Clientes = new List<Cliente> { gabriel } };
            var Caixa = new Banco { Nome = "Caixa", Clientes = new List<Cliente> { pedro, maria } };
            var Nubank = new Banco { Nome = "Nubank", Clientes = new List<Cliente> { perola, gustavo } };

            ctx.AddRange(gustavo, gabriel, pedro, Santander, Itau, Caixa, Nubank);
            await ctx.SaveChangesAsync();
            var clientes = await ctx.Clientes
                .Where(u => u.Banco.Any(g => g.Nome == "Caixa"))
                .ToListAsync();

            Console.WriteLine($"Cliente");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"{cliente.Nome}");
            }



                Console.ReadLine();
        }
    }
}
