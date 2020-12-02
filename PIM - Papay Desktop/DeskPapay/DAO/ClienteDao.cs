using DeskPapay.MODEL;
using DeskPapay.VIEW;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskPapay.DAO
{
    public class ClienteDao : Dao
    {
        
       //private readonly MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader dados;
        private Cliente cliente { get; set; }
        private string sql { get; set; }

        public void Inserir(Cliente cliente)
        {
            try
            {
                AbrirConexao();

                string sql = "insert into pessoas (ID_Pessoa, Nome_Pessoa, Cpf_Pessoa, End_Pessoa, Tel_Pessoa ) values (null, @Nome_Pessoa, @Cpf_Pessoa, @End_Pessoa, @Tel_Pessoa)";
                using (MySqlCommand comando = new MySqlCommand())
                {
                    comando.Connection = conexao; //utilizando conexao validada
                    comando.CommandType = CommandType.Text; //definindo tipo de conexao 'query'
                    comando.CommandText = sql; //atribuindo query ao CommandText

                    comando.Parameters.AddWithValue("@Nome_Pessoa", cliente.Nome);//definindo parametros de entrada da query
                    comando.Parameters.AddWithValue("@Cpf_Pessoa", cliente.Cpf);
                    comando.Parameters.AddWithValue("@End_Pessoa", cliente.Endereco);
                    comando.Parameters.AddWithValue("@Tel_Pessoa", cliente.Telefone);

                    comando.ExecuteNonQuery();
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            finally
            {
                FecharConexao();
            }

        }

        public Cliente Buscar(int id)
        {

            try
            {
                AbrirConexao();

                sql = "select * from pessoas where ID_Pessoa = @Id";

                using (MySqlCommand comando = new MySqlCommand()) //objetos que serão utilizados dentro do bloco
                {
                    comando.Connection = conexao; //utilizando conexao validada
                    comando.CommandType = CommandType.Text; //definindo tipo de conexao 'query'
                    comando.CommandText = sql; //atribuindo query ao CommandText

                    comando.Parameters.AddWithValue("@Id", id);//definindo parametros de entrada da query

                    dados = comando.ExecuteReader();
                                        

                    while (dados.Read())
                    {
                        cliente = new Cliente
                        {
                            Id = Convert.ToInt16(dados["ID_Pessoa"]),
                            Nome = dados["Nome_Pessoa"].ToString(),
                            Cpf = dados["Cpf_Pessoa"].ToString(),
                            Endereco = dados["End_Pessoa"].ToString(),
                            Telefone = dados["Tel_Pessoa"].ToString()
                        };
                    }
                    return cliente;
                }
                                
            }
            catch (Exception)
            {
                MessageBox.Show("Cliente não encontrado");
                return default; //default cria um objeto do tipo do metódo e o retorna vazio
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Deletar(int id)
        {
            try
            {
                AbrirConexao();

                sql = "DELETE FROM pessoas where ID_Pessoa = @Id";

                using (MySqlCommand comando = new MySqlCommand()) //objetos que serão utilizados dentro do bloco
                {
                    comando.Connection = conexao; 
                    comando.CommandType = CommandType.Text; 
                    comando.CommandText = sql; 

                    comando.Parameters.AddWithValue("@Id", id);//definindo parametros de entrada da query

                    comando.ExecuteNonQuery();
                    
                    MessageBox.Show("Dados Excluidos com sucesso");
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Cliente não encontrado");
                /*return default;*/ //default cria um objeto do tipo do metódo e o retorna vazio
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Alterar(int id, Cliente cliente)
        {
            try
            {
                AbrirConexao();
                //frmPessoa altera = new frmPessoa();

                sql = "UPDATE pessoas SET Nome_Pessoa = @Nome, Cpf_Pessoa = @Cpf, End_Pessoa = @Endereco,"+
                    "Tel_Pessoa = @Telefone WHERE ID_Pessoa = @Id";

                using (MySqlCommand comando = new MySqlCommand()) //objetos que serão utilizados dentro do bloco
                {
                    comando.Connection = conexao;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@Id", id);//definindo parametros de entrada da query
                    comando.Parameters.AddWithValue("@Nome", cliente.Nome);
                    comando.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                    comando.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                    comando.Parameters.AddWithValue("@Telefone", cliente.Telefone);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Dados Alterados com sucesso");
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Cliente não encontrado");
                /*return default;*/ //default cria um objeto do tipo do metódo e o retorna vazio
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
