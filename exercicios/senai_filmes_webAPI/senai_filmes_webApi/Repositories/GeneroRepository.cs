using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos gêneros
    /// </summary>
    public class GeneroRepository :  IGeneroRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source = Nome do servidor
        /// initial catalog = Nome do banco de dados
        /// user Id=sa; pwd=senai@132 = Faz a autenticação com o usuário do SQL Server, passando o logon e a senha
        /// integrated security=true = Faz a autenticação com o usuário do sistema (Windows)
        /// </summary>
        private string stringConexao = "Data Source=CAIC-MATEUS-DEV; initial catalog=Filmes; user Id=sa; pwd=Ca07ic05";
        //private string stringConexao = "Data Source=DESKTOP-SP7RV1S\\SQLEXPRESS; initial catalog=Filmes; integrated security=true";

        /// <summary>
        /// Atualiza um genero passando seu idpelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informações</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdCorpo = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdCorpo, con))
                {
                    cmd.Parameters.AddWithValue("@ID", genero.idGenero);
                    cmd.Parameters.AddWithValue("Nome", genero.nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdUrl = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("Nome", genero.nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Busca um genero pelo id
        /// </summary>
        /// <param name="id">id do genero que será buscado</param>
        /// <returns>Um genero buscado, ou null se nao for encontrado</returns>
        public GeneroDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "SELECT idGenero, Nome FROM Generos WHERE idGenero = @ID";

                // Abre a conexão com o banco
                con.Open();

                // Declara o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;

                // Declara o Sql command cmd passando a query que será executada e a conexão como parametro
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor para o parametro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Verifica se o resultado da query resoltou algum registro
                    if (rdr.Read())
                    {
                        // Se sim, instancia um novo objeto  generoBuscado do tipo GeneroDomain
                        GeneroDomain generoBuscado = new GeneroDomain
                        {
                            // Atribui a propriedade idGenero o valor da coluna "idGenero" da tabela do Banco de Dados
                            idGenero = Convert.ToInt32(rdr["idGenero"]),

                            // Atribui a propriedade nome o valor da coluna "Nome" da tabela dp banco de dados
                            nome = rdr["Nome"].ToString()


                        };

                        //Retorna o generoBuscado com os dados obtidos
                        return generoBuscado;

                    }
                    // Se nao, retorna null
                    return null;
                }
            }
        }


        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero"> Objeto chamado novo genero com as informações que serão cadastras</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            // Declara a conexão con, passando a string de Conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                //INSERT INTO Generos(Nome) VALUES ('Ficçao cientifica');
                //string queryInsert = "INSERT INTO Generos(Nome) VALUES ('" + novoGenero.nome +"')";
                //Não usar dessa forma, pois pode causar o efeito joana d'arc
                //Além de permitir SQL INJECTION
                // Por exemplo "nome" : 'Perdeu mane) DROP DATABASE --"
                //Com isso deletar seu banco

                // Declara a query que será executada
                string queryInsert = "INSERT INTO Generos(Nome) VALUES (@Nome)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parametros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parametro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.nome);

                    // Abre conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Deleta um genero atraves do seu id
        /// </summary>
        /// <param name="id">id do genero que será deletado</param>
        public void Deletar(int id)
        {
            // Declara o SqlConnection con pasando a stringConexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada passando o parametro @ID
                string queryDelete = "DELETE FROM Generos WHERE idGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Define o valor do id recebido no metodo como o valor de parametro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexao com o Banco de Dados
                    con.Open();

                    //Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        public List<GeneroDomain> ListarTodos()
        {
            // Cria uma lista listaGeneros onde serão armazenados os dados
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT idGenero, Nome FROM Generos";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto genero do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            // Atribui à propriedade idGenero o valor da primeira coluna da tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade nome o valor da segunda coluna da tabela do banco de dados
                            nome = rdr[1].ToString()
                        };

                        // Adiciona o objeto genero criado à lista listaGeneros
                        listaGeneros.Add(genero);
                    }
                }
            }

            // Retorna a lista de gêneros
            return listaGeneros;
        }
        
    }
}
