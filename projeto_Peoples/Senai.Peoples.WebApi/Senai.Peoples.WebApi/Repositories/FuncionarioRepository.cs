using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source = Nome do servidor
        /// initial catalog = Nome do banco de dados
        /// user Id=sa; pwd=senai@132 = Faz a autenticação com o usuário do SQL Server, passando o logon e a senha
        /// </summary>
        private string stringConexao = "Data Source=CAIC-MATEUS-DEV; initial catalog=T_Peoples; user Id=sa; pwd=Ca07ic05";

        public void AtualizarIdCorpo(FuncionarioDomain funcionario)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, FuncionarioDomain genero)
        {
            throw new NotImplementedException();
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "SELECT idFuncionario, Nome, Sobrenome FROM Funcionarios WHERE idFuncionario = @ID";

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
                        // Se sim, instancia um novo objeto  funcionarioBuscado
                        FuncionarioDomain funcionarioBuscado = new FuncionarioDomain
                        {
                            // Atribui a propriedade idGenero o valor da coluna "idFuncionario" da tabela do Banco de Dados
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),

                            // Atribui a propriedade nome o valor da coluna "Nome" da tabela dp banco de dados
                            nome = rdr["Nome"].ToString(),

                            // Atribui a propriedade nome o valor da coluna "Sobrenome" da tabela dp banco de dados

                            sobrenome = rdr ["Sobrenome"].ToString()


                        };

                        //Retorna o generoBuscado com os dados obtidos
                        return funcionarioBuscado;

                    }
                    // Se nao, retorna null
                    return null;
                }
            }
        }
        /// <summary>
        /// Cadastra um funcionario
        /// </summary>
        /// <param name="novoFuncionario"> objeto novoFuncionario com as informações para serem cadastradas</param>
        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            // Declara a conexão con, passando a string de Conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                // Declara a query que será executada
                string queryInsert = "INSERT INTO Funcionarios(Nome) VALUES (@Nome), (Sobrenome) (@Sobrenome)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parametros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parametro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoFuncionario.nome);
                    //Passa o valor para o parametro @Sobrenome
                    cmd.Parameters.AddWithValue("@Sobrenome", novoFuncionario.sobrenome);

                    // Abre conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<FuncionarioDomain> ListarTodos()
        {
            // Cria uma lista listaFuncionarios onde serão armazenados os dados
            List<FuncionarioDomain> listaFuncionarios = new List<FuncionarioDomain>();

            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT idFuncionario, Nome, Sobrenome FROM Funcionarios";

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
                        // Instancia um objeto genero do tipo FuncionarioDomain
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            // Atribui à propriedade idFuncionario o valor da primeira coluna da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),

                            // Atribui à propriedade nome o valor da segunda coluna da tabela do banco de dados
                            nome = rdr["Nome"].ToString(),

                            // Atribui à propriedade nome o valor da terceira coluna da tabela do banco de dados
                            sobrenome = rdr["Sobrenome"].ToString()
                        };

                        // Adiciona o objeto funcionario criado à lista listaFuncionarios
                        listaFuncionarios.Add(funcionario);
                    }
                }
            }

            // Retorna a lista de funcionarios
            return listaFuncionarios;
        }
    }
    }

