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
    public class Fornecedor_Dao : Dao
    {
        public Fornecedor fornecedor { get; set; }

        public Fornecedor_Dao()
        {

        }

        public void Inserir(Fornecedor fornecedor)
        {
            try
            {
                AbrirConexao();

                string sql = "INSERT INTO fornecedor (ID_Fornecedor, Razao_Social, CNPJ, End_Fornecedor, Telefone )"+
                    "values (null, @Razao_Social, @CNPJ, @Endereco, @Telefone)";
                using (MySqlCommand comando = new MySqlCommand())
                {
                    comando.Connection = conexao; //utilizando conexao validada
                    comando.CommandType = CommandType.Text; //definindo tipo de conexao 'query'
                    comando.CommandText = sql; //atribuindo query ao CommandText

                    comando.Parameters.AddWithValue("@Razao_Social", fornecedor.RazaoSocial);//definindo parametros de entrada da query
                    comando.Parameters.AddWithValue("@CNPJ", fornecedor.Cnpj);
                    comando.Parameters.AddWithValue("@Endereco", fornecedor.Endereco);
                    comando.Parameters.AddWithValue("@Telefone", fornecedor.Telefone);

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

        public Fornecedor Buscar(int id)
        {

            try
            {
                AbrirConexao();

                sql = "SELECT * FROM fornecedor WHERE ID_Fornecedor = @Id";

                using (MySqlCommand comando = new MySqlCommand()) //objetos que serão utilizados dentro do bloco
                {
                    comando.Connection = conexao; //utilizando conexao validada
                    comando.CommandType = CommandType.Text; //definindo tipo de conexao 'query'
                    comando.CommandText = sql; //atribuindo query ao CommandText

                    comando.Parameters.AddWithValue("@Id", id);//definindo parametros de entrada da query

                    dados = comando.ExecuteReader();


                    while (dados.Read())
                    {
                        fornecedor = new Fornecedor
                        {
                            Id_fornecedor = Convert.ToInt16(dados["ID_Fornecedor"]),
                            RazaoSocial = dados["Razao_Social"].ToString(),
                            Cnpj = dados["CNPJ"].ToString(),
                            Endereco = dados["End_Fornecedor"].ToString(),
                            Telefone = dados["Telefone"].ToString()
                        };
                    }
                    return fornecedor;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("fornecedor não encontrado");
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

                sql = "DELETE FROM fornecedor WHERE ID_Fornecedor = @Id";

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
                MessageBox.Show("fornecedor não encontrado");
                /*return default;*/ //default cria um objeto do tipo do metódo e o retorna vazio
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Alterar(int id, Fornecedor fornecedor)
        {
            try
            {
                AbrirConexao();
                //frmPessoa altera = new frmPessoa();

                sql = "UPDATE fornecedor SET Razao_Social = @Razao_Social, CNPJ = @CNPJ, End_Fornecedor = @End_Fornecedor," +
                    "Telefone = @Telefone WHERE ID_Fornecedor = @Id";

                using (MySqlCommand comando = new MySqlCommand()) //objetos que serão utilizados dentro do bloco
                {
                    comando.Connection = conexao;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@Id", id);//definindo parametros de entrada da query
                    comando.Parameters.AddWithValue("@Razao_Social", fornecedor.RazaoSocial);
                    comando.Parameters.AddWithValue("@CNPJ", fornecedor.Cnpj);
                    comando.Parameters.AddWithValue("@End_Fornecedor", fornecedor.Endereco);
                    comando.Parameters.AddWithValue("@Telefone", fornecedor.Telefone);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Dados Alterados com sucesso");
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("fornecedor não encontrado");
                /*return default;*/ //default cria um objeto do tipo do metódo e o retorna vazio
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
