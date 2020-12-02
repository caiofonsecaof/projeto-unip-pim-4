using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace DeskPapay.DAO
{
    public abstract class Dao
    {
        protected MySqlCommand comando;
        protected MySqlConnection conexao;
        protected MySqlDataReader dados;
        protected string sql;
       

        public Dao()
        {
            comando = new MySqlCommand();
            conexao = new MySqlConnection();
        }

        protected void AbrirConexao() 
        {
            try 
            {
                conexao.ConnectionString = "server=localhost; port=3306;User Id=root; database=bd_papay; password=MANAGER";
                conexao.Open();
            }
            catch (Exception erro)
            {
                MessageBox.Show("A conexão com o banco de dados falhou, contate o suporte!"+erro.Message); //VERIFICAR DEPOIS
            }
            
        }

        protected void FecharConexao()
        {
            conexao.Close();
        }
        
        
    }
}
