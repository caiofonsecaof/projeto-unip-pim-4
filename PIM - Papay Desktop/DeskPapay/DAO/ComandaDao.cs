using DeskPapay.DTO;
using DeskPapay.MODEL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskPapay.DAO
{
    public class ComandaDao : Dao
    {
        private ComandaDTO comanda;
        private Produto produto;

        public ComandaDao()
        {

        }

        public void InserirComandas(ComandaDTO comanda)
        {
            try
            {
                AbrirConexao();

                string sql = "INSERT INTO comanda (ID, ID_Comanda, Fk_Produto)" +
                    "values (null, @ID_Comanda, @Fk_Produto)";
                using (MySqlCommand comando = new MySqlCommand())
                {
                    comando.Connection = conexao; //utilizando conexao validada
                    comando.CommandType = CommandType.Text; //definindo tipo de conexao 'query'
                    comando.CommandText = sql; //atribuindo query ao CommandText

                    comando.Parameters.AddWithValue("@ID_Comanda", comanda.IdComanda);
                    comando.Parameters.AddWithValue("@Fk_Produto", comanda.IdProduto);


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

        public List<ComandaDTO> BuscarComandas(int idcomanda)
        {
            try
            {
                AbrirConexao();

                sql = @"SELECT c.ID,c.ID_Comanda,p.ID_Produto,p.Nome_Produto, p.Descricao, p.Valor_Produto
                        FROM comanda c
                        INNER JOIN produtos p 
                        ON c.Fk_produto = p.ID_Produto
                        WHERE c.ID_Comanda = @Id";

                using (MySqlCommand comando = new MySqlCommand()) //objetos que serão utilizados dentro do bloco
                {
                    comando.Connection = conexao; //utilizando conexao validada
                    comando.CommandType = CommandType.Text; //definindo tipo de conexao 'query'
                    comando.CommandText = sql; //atribuindo query ao CommandText

                    comando.Parameters.AddWithValue("@Id", idcomanda);//definindo parametros de entrada da query

                    var retorno = comando.ExecuteReader();

                    List<ComandaDTO> comandas = new List<ComandaDTO>();

                    while (retorno.Read()) //le linha a linha do retorno sql
                    {
                        comanda = new ComandaDTO
                        {
                            Id = Convert.ToInt16(retorno["ID"]),
                            IdProduto = Convert.ToInt16(retorno["ID_Produto"]),
                            IdComanda = Convert.ToInt16(retorno["ID_Comanda"]),
                            NomeProduto = retorno["Nome_Produto"].ToString(),
                            DescricaoProduto = retorno["Descricao"].ToString(),
                            ValorProduto = Convert.ToDouble(retorno["Valor_Produto"]),
                        };

                        comandas.Add(comanda); //adiciona itens na lista
                    }
                    return comandas; //retorna lista
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Comanda não encontrada");
                return default; //default cria um objeto do tipo do metódo e o retorna vazio
            }
            finally
            {
                FecharConexao();
            }
        }

        public void RemoverComanda(int id)
        {
            try
            {
                AbrirConexao();

                string sql = "DELETE FROM comanda WHERE ID = @ID";

                using (MySqlCommand comando = new MySqlCommand())
                {
                    comando.Connection = conexao; //utilizando conexao validada
                    comando.CommandType = CommandType.Text; //definindo tipo de conexao 'query'
                    comando.CommandText = sql; //atribuindo query ao CommandText

                    comando.Parameters.AddWithValue("@ID", id);
                    

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

    }
}
