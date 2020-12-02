using DeskPapay.MODEL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DeskPapay.DAO
{
    //Dao 
    public class LoginDao : Dao
    {
        MySqlDataReader dados;

        public bool EfetuarLogin(Login login)
        {
            try
            {
                AbrirConexao();

                string sql = "select * from credenciais where Login = @Login and Senha = @Senha";

                using (MySqlCommand comando = new MySqlCommand()) //objetos que serão utilizados dentro do bloco
                {
                    comando.Connection = conexao; //utilizando conexao validada
                    comando.CommandType = CommandType.Text; //definindo tipo de conexao 'query'
                    comando.CommandText = sql; //atribuindo query ao CommandText

                    comando.Parameters.AddWithValue("@Login", login.UserName);//definindo parametros de entrada da query
                    comando.Parameters.AddWithValue("@Senha", login.UserSenha);//definindo parametros de entrada da query 

                    dados = comando.ExecuteReader();

                    return dados.HasRows; //retorna valor booleano
                }

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                FecharConexao();
            }

        }
    }
}
