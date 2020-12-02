using DeskPapay.DAO;
using DeskPapay.MODEL;


namespace DeskPapay.CTR
{
    public class Ctr_Funcionario
    {
        private readonly FuncionarioDao funcionarioDao;
        private Funcionario funcionario;

        public Ctr_Funcionario()
        {
            funcionarioDao = new FuncionarioDao();
            funcionario = new Funcionario();
        }

        public void Inserir(Funcionario funcionario)
        {
            funcionarioDao.Inserir(funcionario);
        }

        public Funcionario Buscar(int id)
        {
            return funcionarioDao.Buscar(id);
        }

        public void Deletar(int id)
        {
            Funcionario funcionario = new Funcionario();

            if (funcionario.Nome != "")
            {
                funcionarioDao.Deletar(id);
            }
        }

        public void Alterar(int id, Funcionario funcionario)
        {
            if (funcionario.Nome != "")
            {
                funcionarioDao.Alterar(id, funcionario);
            }
        }
    }
}
