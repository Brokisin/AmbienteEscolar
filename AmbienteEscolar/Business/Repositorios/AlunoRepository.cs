using AmbienteEscolar.Business.Classes;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using AmbienteEscolar.Business.BancoDeDados;

namespace AmbienteEscolar.Business.Repositorios
{
    public class AlunoRepository
    {
        Banco banco = new Banco();

        public static List<String> BuscarNomeAlunos()
        {
            List<string> alunos = new List<string>();
            
            string query = "SELECT nome FROM aluno ORDER BY id;";
            
            try
            {
                if (BancoDados.OpenConnection() == true)
                {
                    MySqlCommand command = new MySqlCommand(query, BancoDados.connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            alunos.Add(reader[0] + "");
                        }
                        reader.Close();
                        BancoDados.CloseConnection();
                        return alunos;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return alunos;
        }

        public static List<Aluno> ListarAlunos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT * FROM aluno");
            sb.AppendLine("ORDER BY id;");

            List<Aluno> listaAlunos = new List<Aluno>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Aluno aluno = new Aluno();

                    aluno.Id = int.Parse(dataReader["id"].ToString());
                    aluno.Nome = dataReader["nome"].ToString();
                    aluno.Email = dataReader["email"].ToString();
                    aluno.Id_curso = int.Parse(dataReader["id_curso"].ToString());

                    listaAlunos.Add(aluno);
                }
                dataReader.Close();
                BancoDados.CloseConnection();

                return listaAlunos;
            }
            else
            {
                return listaAlunos;
            }
        }




        /*public static List<string>[] ListarAlunos()
        {
            List<string> listaAlunos = new List<string>();
            List<Aluno> listaAlunos2 = new List<Aluno>();
            Aluno aluno = new Aluno();

            string query = "SELECT * FROM aluno";
            
            
            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                
                while (dataReader.Read())
                {
                    aluno.Id = int.Parse(dataReader["id"].ToString());
                    aluno.Nome = dataReader["nome"].ToString();
                    aluno.Email = dataReader["email"].ToString();
                    aluno.Id_curso = int.Parse(dataReader["id_curso"].ToString());

                    listaAlunos2.Add(aluno);
                }
                dataReader.Close();
                BancoDados.CloseConnection();
                
                return aluno;
            }
            else
            {
                return aluno;
            }
        }*/

        public static void InserirAluno(string nome, string email, int id_curso)
        {
            string query = "INSERT INTO aluno (nome, email, id_curso) VALUES('" + nome + "','" + email + "'," + id_curso + ");";
            
            if (BancoDados.OpenConnection() == true)
            {
                MySqlConnection connection = new MySqlConnection();
                MySqlCommand cmd = new MySqlCommand(query, BancoDados.connection);
                
                cmd.ExecuteNonQuery();
                
                BancoDados.CloseConnection();
            }
        }
    }
}