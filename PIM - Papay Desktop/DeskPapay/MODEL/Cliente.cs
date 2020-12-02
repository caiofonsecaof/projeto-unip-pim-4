using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskPapay.MODEL
{
    public class Cliente:Pessoa
    {

        public Cliente()
        {

        }

        public Cliente(string nome, string cpf, string endereco, string telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            Telefone = telefone;
        }

    }

}
