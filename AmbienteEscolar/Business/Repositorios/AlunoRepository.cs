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

        public static List<Aluno> ListarNomeAlunos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT nome FROM aluno");
            sb.AppendLine("ORDER BY id;");

            List<Aluno> listaAlunos = new List<Aluno>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Aluno aluno = new Aluno();

                    aluno.Nome = dataReader["nome"].ToString();
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

        public static List<Aluno> ListarAlunos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT a.id, a.nome, a.email, a.id_curso, c.descricao, c.turno FROM aluno a ");
            sb.AppendLine("INNER JOIN curso c ON a.id_curso = c.id;");

            List<Aluno> listaAlunos = new List<Aluno>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Curso curso = new Curso();
                    Aluno aluno = new Aluno();

                    aluno.Id = int.Parse(dataReader["id"].ToString());
                    aluno.Nome = dataReader["nome"].ToString();
                    aluno.Email = dataReader["email"].ToString();
                    curso.Id = int.Parse(dataReader["id_curso"].ToString());
                    curso.Descricao = dataReader["descricao"].ToString();
                    curso.Turno = dataReader["turno"].ToString();
                    aluno.Curso = curso;

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

        public static bool InserirAluno(string nome, string email, int id_curso)
        {
            string query = "INSERT INTO aluno (nome, email, id_curso) VALUES('" + nome + "','" + email + "'," + id_curso + ");";

            if (BancoDados.OpenConnection() == true)
            {
                MySqlConnection connection = new MySqlConnection();
                MySqlCommand cmd = new MySqlCommand(query, BancoDados.connection);

                cmd.ExecuteNonQuery();

                BancoDados.CloseConnection();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}