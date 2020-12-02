using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskPapay.DTO
{

    

    public class ComandaDTO
    {
        public int Id { get; set; }
        public int IdComanda { get; set; }
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public double ValorProduto { get; set; }

        public ComandaDTO()
        {

        }
        public ComandaDTO(string nome, double valor)
        {

            NomeProduto = nome;
            ValorProduto = valor;
        }



    }
}
