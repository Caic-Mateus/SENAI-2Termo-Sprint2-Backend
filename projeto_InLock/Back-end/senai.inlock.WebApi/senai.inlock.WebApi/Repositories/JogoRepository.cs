using senai.inlock.WebApi.Domains;
using senai.inlock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.WebApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=CAIC-MATEUS-DEV; initial catalog=inlock_games_tarde; user Id=sa; pwd=Ca07ic05";

        public void AtualizarIdUrl(int id, JogoDomain jogo)
        {
            throw new NotImplementedException();
        }

        public JogoDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(JogoDomain novoJogo)
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
                string queryInsert = "INSERT INTO Jogos(nomeJogo, descricao, dataLancamento, valor , idEstudio)  VALUES (@Nome, @Descricao, @Data, @Valor, @IdEstudio)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parametros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parametro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@Data", novoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.idEstudio);

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


        public List<JogoDomain> ListarJogos()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, jogos.idEstudio, estudios.nomeEstudio FROM jogos INNER JOIN estudios ON jogos.idEstudio = estudios.idEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr["idJogo"]),

                            nomeJogo = rdr["nomeJogo"].ToString(),

                            descricao = rdr["descricao"].ToString(),

                            dataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),

                            valor = Convert.ToDouble(rdr["valor"]),

                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),

                            estudio = new EstudioDomain
                            {
                                idEstudio = Convert.ToInt32(rdr["idEstudio"]),

                                nomeEstudio = rdr["nomeEstudio"].ToString()
                            }

                        };
                        listaJogos.Add(jogo);
                    }
                }
            }
            return listaJogos;
        }
    }
}