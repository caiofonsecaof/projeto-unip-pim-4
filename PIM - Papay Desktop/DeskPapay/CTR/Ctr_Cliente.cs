using DeskPapay.DAO;
using DeskPapay.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskPapay.CTR
{
    public class Ctr_Cliente
    {

        private readonly ClienteDao clienteDao;
        private Cliente cliente ;

        public Ctr_Cliente()
        {
            clienteDao = new ClienteDao();
            cliente = new Cliente();
        }

        public void Inserir(Cliente cliente)
        {
            clienteDao.Inserir(cliente);
        }

        public Cliente Buscar(int id)
        {
            return clienteDao.Buscar(id);

        }

        public void Deletar(int id)
        {
            
            //parecido com inserir, verificar radio button
            if (cliente.Nome != "")
            {
                clienteDao.Deletar(id);
            }

        }

        public void Alterar(int id,Cliente cliente)
        {
            if (cliente.Nome != "")
            {
                clienteDao.Alterar(id,cliente);
            }
        }

    }
}
