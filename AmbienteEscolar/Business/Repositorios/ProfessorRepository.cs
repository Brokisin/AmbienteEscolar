using AmbienteEscolar.Business.BancoDeDados;
using AmbienteEscolar.Business.Classes;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AmbienteEscolar.Business.Repositorios
{
    public class ProfessorRepository
    {
        Banco banco = new Banco();

        public static List<Professor> ListarProfessores()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT p.id, p.nome, p.email, p.id_curso, c.descricao, c.id_turno, t.descricao FROM professor p");
            sb.AppendLine("INNER JOIN curso c ON p.id_curso = c.id INNER JOIN turno t ON t.id = c.id_turno;");

            List<Professor> listaProfessores = new List<Professor>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Curso curso = new Curso();
                    Professor professor = new Professor();

                    professor.Id = int.Parse(dataReader["id"].ToString());
                    professor.Nome = dataReader["nome"].ToString();
                    professor.Email = dataReader["email"].ToString();

                    curso.Id = int.Parse(dataReader["id_curso"].ToString());
                    curso.Descricao = dataReader["descricao"].ToString();
                    curso.Turno = dataReader["turno"].ToString();

                    professor.Curso = curso;

                    listaProfessores.Add(professor);
                }
                dataReader.Close();
                BancoDados.CloseConnection();

                return listaProfessores;
            }
            else
            {
                return listaProfessores;
            }
        }

        public static bool InserirProfessor(string nome, string email, int id_curso)
        {
            string query = "INSERT INTO professor (nome, email, id_curso) VALUES('" + nome + "','" + email + "'," + id_curso + ");";

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