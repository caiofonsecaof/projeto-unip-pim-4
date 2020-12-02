using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskPapay.MODEL
{
    public class Fornecedor:Pessoa
    {
        public int Id_fornecedor { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }

        public Fornecedor()
        {

        }

        public Fornecedor(string razaosocial, string cnpj, string endereco, string telefone)
        {
            RazaoSocial = razaosocial;
            Cnpj = cnpj;
            Endereco = endereco;
            Telefone = telefone;
        }
    }
}
