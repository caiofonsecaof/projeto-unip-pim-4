using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskPapay.MODEL
{
    public class Comanda
    {
        public Produto Produto { get; set; }
        public int IdComanda { get; set; }

        public Comanda()
        {
            
        }

        public Comanda(Produto produto)
        {
            Produto = produto;
        }
    }
}
