using DeskPapay.MODEL;
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
    public class FuncionarioDao : Dao
    {
        private Funcionario funcionario;

        public FuncionarioDao()
        {
            funcionario = new Funcionario();
        }

        public void Inserir(Funcionario funcionario)
        {
            try
            {
                AbrirConexao();

                string sql = "insert into pessoas (ID_Pessoa, Nome_Pessoa, Cpf_Pessoa, End_Pessoa, Tel_Pessoa, Func_Salario, Func_Cargo )" +
                    "values (null, @Nome_Pessoa, @Cpf_Pessoa, @End_Pessoa, @Tel_Pessoa, @Salario, @Cargo )";

                using (MySqlCommand comando = new MySqlCommand())
                {
                    comando.Connection = conexao; //utilizando conexao validada
                    comando.CommandType = CommandType.Text; //definindo tipo de conexao 'query'
                    comando.CommandText = sql; //atribuindo query ao CommandText

                    comando.Parameters.AddWithValue("@Nome_Pessoa", funcionario.Nome);//definindo parametros de entrada da query
                    comando.Parameters.AddWithValue("@Cpf_Pessoa", funcionario.Cpf);
                    comando.Parameters.AddWithValue("@End_Pessoa", funcionario.Endereco);
                    comando.Parameters.AddWithValue("@Tel_Pessoa", funcionario.Telefone);
                    comando.Parameters.AddWithValue("@Salario", funcionario.Salario);
                    comando.Parameters.AddWithValue("@Cargo", funcionario.Cargo);

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

        public Funcionario Buscar(int id)
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
                        funcionario = new Funcionario
                        {
                            Id = Convert.ToInt16(dados["ID_Pessoa"]),
                            Nome = dados["Nome_Pessoa"].ToString(),
                            Cpf = dados["Cpf_Pessoa"].ToString(),
                            Endereco = dados["End_Pessoa"].ToString(),
                            Telefone = dados["Tel_Pessoa"].ToString(),
                            Cargo = dados["Func_Cargo"].ToString(),
                            Salario = Convert.ToDouble(dados["Func_Salario"])
                        };
                    }
                    return funcionario;
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
                MessageBox.Show("Funcionário não encontrado");
                /*return default;*/ //default cria um objeto do tipo do metódo e o retorna vazio
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Alterar(int id, Funcionario funcionario)
        {
            try
            {
                AbrirConexao();
                //frmPessoa altera = new frmPessoa();

                sql = "UPDATE pessoas SET Nome_Pessoa = @Nome, Cpf_Pessoa = @Cpf, End_Pessoa = @Endereco," +
                    "Tel_Pessoa = @Telefone, Func_Salario = @Salario, Func_Cargo = @Cargo   WHERE ID_Pessoa = @Id";

                using (MySqlCommand comando = new MySqlCommand()) //objetos que serão utilizados dentro do bloco
                {
                    comando.Connection = conexao;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@Id", id);//definindo parametros de entrada da query
                    comando.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    comando.Parameters.AddWithValue("@Cpf", funcionario.Cpf);
                    comando.Parameters.AddWithValue("@Endereco", funcionario.Endereco);
                    comando.Parameters.AddWithValue("@Telefone", funcionario.Telefone);
                    comando.Parameters.AddWithValue("@Salario", funcionario.Salario);
                    comando.Parameters.AddWithValue("@Cargo", funcionario.Cargo);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Dados Alterados com sucesso");
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Funcionário não encontrado");
                /*return default;*/ //default cria um objeto do tipo do metódo e o retorna vazio
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
