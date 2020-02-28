using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionariosRepositories : IFuncionariosInterface
    {
        private string stringConexao = "Data Source=N-1S-DEV-17\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132";

        public void Atualizar(int id, FuncionariosDomains funcionarios)
        {
            throw new NotImplementedException();
        }

        public void AtualizarId(int id, FuncionariosDomains funcionarios)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdate = "UPDATE funcionarios SET Nome = @Nome WHERE Id = @ID";
                //string queryUpdate = "UPDATE funcionarios SET Sobrenome = @Sobrenome WHERE Id = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);
                    //cmd.Parameters.AddWithValue("@Sobrenome", funcionarios.Sobrenome);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public FuncionariosDomains BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdFuncionarios, Nome, Sobrenome FROM funcionarios WHERE IdFuncionarios = @Id";
                con.Open();

                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FuncionariosDomains funcionarios = new FuncionariosDomains
                        {
                            IdFuncionarios = Convert.ToInt32(rdr["IdFuncionarios"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome= rdr["Sobrenome"].ToString()

                        };
                        return funcionarios;
                    }
                  return null;
                }
            }
        }

        public void Cadastrar(int id, FuncionariosDomains funcionario)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Funcionarios (Nome, Sobrenome) VALUES (@Nome, @Sobrenome)";
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                con.Open();
                cmd.ExecuteNonQuery();


            }
        }

        // SÓ DELETA O  QUERIDO AMIGO POR ID, NAO PRECISA DE NOME E NEM SOBRENOME ?
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
                
            {
                string queryDelete = "DELETE IdFuncionarios FROM Funcionarios WHERE IdFuncionarios = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
           
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionariosDomains> Listar()
        {
            List<FuncionariosDomains> funcionarios = new List<FuncionariosDomains>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdFuncionarios, Nome, Sobrenome from Funcionarios";

                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FuncionariosDomains funcionario= new FuncionariosDomains
                        {
                            IdFuncionarios = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr ["Sobrenome"].ToString()
                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }
    }
}
