using DeskPapay.DAO;
using DeskPapay.MODEL;


namespace DeskPapay.CTR
{
    public class Ctr_Fornecedor
    {
        private readonly Fornecedor_Dao fornecedorDao;
        private Fornecedor fornecedor;

        public Ctr_Fornecedor()
        {
            fornecedorDao = new Fornecedor_Dao();
            fornecedor = new Fornecedor();
        }

        public void Inserir(Fornecedor fornecedor)
        {
            fornecedorDao.Inserir(fornecedor);
        }

        public Fornecedor Buscar(int id)
        {
           return fornecedorDao.Buscar(id);
        }

        public void Deletar(int id)
        {
            if (fornecedor.RazaoSocial != "")
            {
                fornecedorDao.Deletar(id);
            }
                
        }

        public void Alterar(int id, Fornecedor fornecedor)
        {
            if (fornecedor.RazaoSocial != "")
            {
                fornecedorDao.Alterar(id, fornecedor);
            }
        }
    }
}
