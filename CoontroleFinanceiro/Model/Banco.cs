using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoontroleFinanceiro.Model
{
    internal class Banco
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
