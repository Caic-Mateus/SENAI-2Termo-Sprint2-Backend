using senai.inlock.WebApi.Domains;
using senai.inlock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.WebApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {

        private string stringConexao = "Data Source=CAIC-MATEUS-DEV; initial catalog=inlock_games_tarde; user Id=sa; pwd=Ca07ic05";


        public void AtualizarIdUrl(int id, EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdUrl = "UPDATE Estudios SET nomeEstudio = @Nome WHERE idEstudio = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", estudio.nomeEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public EstudioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "SELECT idEstudio, nomeEstudio FROM Estudios WHERE idEstudio = @ID";

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
                        EstudioDomain funcionarioBuscado = new EstudioDomain
                        {
                            // Atribui a propriedade idGenero o valor da coluna "idFuncionario" da tabela do Banco de Dados
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),

                            // Atribui a propriedade nome o valor da coluna "Nome" da tabela dp banco de dados
                            nomeEstudio = rdr["nomeEstudio"].ToString()

                        };
                        //Retorna o generoBuscado com os dados obtidos
                        return funcionarioBuscado;

                    }
                    // Se nao, retorna null
                    return null;
                }
            }
        }

        public void Cadastrar(EstudioDomain novoEstudio)
        {
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
                string queryInsert = "INSERT INTO Estudios(nomeEstudio) VALUES (@Nome)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parametros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parametro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoEstudio.nomeEstudio);

                    // Abre conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada passando o parametro @ID
                string queryDelete = "DELETE FROM Estudios WHERE idEstudio = @ID";

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

        public List<EstudioDomain> ListarEstudios()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();
        
            using (SqlConnection con = new SqlConnection (stringConexao))
            {
                string querySelectAll = "SELECT idEstudio, nomeEstudio FROM estudios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand (querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),

                            nomeEstudio = rdr["nomeEstudio"].ToString()
                        };
                        listaEstudios.Add(estudio);
                    }
                }
            }
            return listaEstudios;
        }
    }
}
