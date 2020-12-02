using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskPapay.MODEL
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Desc { get; set; }
        public double Valor { get; set; }

        public Produto()
        {

        }

        public Produto(string nome, string desc, double valor)
        {
            Nome = nome;
            Desc = desc;
            Valor = valor;
        }

        internal void add(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
