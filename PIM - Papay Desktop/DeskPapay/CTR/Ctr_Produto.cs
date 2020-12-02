using DeskPapay.MODEL;
using DeskPapay.DAO;
using System.Collections.Generic;

namespace DeskPapay.CTR
{
    class Ctr_Produto
    {

        private ProdutoDao produtoDao;
        private Produto produto;
        
        public Ctr_Produto( ) 
        {
            produtoDao = new ProdutoDao();
            produto = new Produto();

        }

        public void Inserir(Produto produto)
        {
            produtoDao.Inserir(produto);
        }

        public Produto Buscar(int id)
        {
            return produtoDao.Buscar(id);
        }

        public List<Produto> Buscar()
        {
            return produtoDao.Buscar();
        }

        public void Deletar(int id)
        {
            if (produto.Nome != "")
            {
                produtoDao.Deletar(id);
            }
        }

        public void Alterar(int id, Produto produto)
        {
            if (produto.Nome != "")
            {
                produtoDao.Alterar(id, produto);
            }
        }
    }
}
