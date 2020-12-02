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
    public class ProdutoDao : Dao
    {
        private Produto produto { get; set; }

        public ProdutoDao()
        {
            
        }

        public void Inserir(Produto produto)
        {
            try
            {
                AbrirConexao();

                string sql = "INSERT INTO produtos (ID_Produto, Nome_Produto, Descricao, Valor_Produto )" +
                    "values (null, @Nome_Produto, @Descricao, @Valor_Produto)";
                using (MySqlCommand comando = new MySqlCommand())
                {
                    comando.Connection = conexao; //utilizando conexao validada
                    comando.CommandType = CommandType.Text; //definindo tipo de conexao 'query'
                    comando.CommandText = sql; //atribuindo query ao CommandText

                    comando.Parameters.AddWithValue("@Nome_Produto", produto.Nome);//definindo parametros de entrada da query
                    comando.Parameters.AddWithValue("@Descricao", produto.Desc);
                    comando.Parameters.AddWithValue("@Valor_Produto", produto.Valor);
                    

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

        public Produto Buscar(int id)
        {

            try
            {
                AbrirConexao();

                sql = "SELECT * FROM produtos WHERE ID_Produto = @Id";

                using (MySqlCommand comando = new MySqlCommand()) //objetos que serão utilizados dentro do bloco
                {
                    comando.Connection = conexao; //utilizando conexao validada
                    comando.CommandType = CommandType.Text; //definindo tipo de conexao 'query'
                    comando.CommandText = sql; //atribuindo query ao CommandText

                    comando.Parameters.AddWithValue("@Id", id);//definindo parametros de entrada da query

                    dados = comando.ExecuteReader();


                    while (dados.Read())
                    {
                        produto = new Produto
                        {
                            Id = Convert.ToInt16(dados["ID_Produto"]),
                            Nome = dados["Nome_Produto"].ToString(),
                            Desc = dados["Descricao"].ToString(),
                            Valor = Convert.ToDouble(dados["Valor_Produto"])
                        };
                    }
                    return produto;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Produto não encontrado");
                return default; //default cria um objeto do tipo do metódo e o retorna vazio
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Produto> Buscar()
        {

            try
            {
                AbrirConexao();

                sql = "SELECT * FROM produtos ";

                using (MySqlCommand comando = new MySqlCommand()) //objetos que serão utilizados dentro do bloco
                {
                    comando.Connection = conexao; //utilizando conexao validada
                    comando.CommandType = CommandType.Text; //definindo tipo de conexao 'query'
                    comando.CommandText = sql; //atribuindo query ao CommandText


                    dados = comando.ExecuteReader();

                    List<Produto> produtos = new List<Produto>();



                    while (dados.Read())
                    {
                        produto = new Produto
                        {
                            Id = Convert.ToInt16(dados["ID_Produto"]),
                            Nome = dados["Nome_Produto"].ToString(),
                            Desc = dados["Descricao"].ToString(),
                            Valor = Convert.ToDouble(dados["Valor_Produto"])
                        };
                        produtos.Add(produto);
                    }
                    return produtos;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Produto não encontrado");
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

                sql = "DELETE FROM comanda WHERE Fk_produto = @Id; DELETE FROM produtos WHERE ID_Produto = @Id";

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
            catch (Exception)
            {
                MessageBox.Show("Produto não encontrado");
                /*return default;*/ //default cria um objeto do tipo do metódo e o retorna vazio
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Alterar(int id, Produto produto)
        {
            try
            {
                AbrirConexao();
                //frmPessoa altera = new frmPessoa();

                sql = "UPDATE produtos SET Nome_Produto = @Nome_Produto, Descricao = @Descricao, Valor_Produto = @Valor_Produto WHERE ID_Produto = @Id";

                using (MySqlCommand comando = new MySqlCommand()) //objetos que serão utilizados dentro do bloco
                {
                    comando.Connection = conexao;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@Id", id);//definindo parametros de entrada da query
                    comando.Parameters.AddWithValue("@Nome_Produto", produto.Nome);
                    comando.Parameters.AddWithValue("@Descricao", produto.Desc);
                    comando.Parameters.AddWithValue("@Valor_Produto", produto.Valor);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Dados Alterados com sucesso");
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("produto não encontrado");
                /*return default;*/ //default cria um objeto do tipo do metódo e o retorna vazio
            }
            finally
            {
                FecharConexao();
            }
        }


    }
}
