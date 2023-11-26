using AmbienteEscolar.Business.BancoDeDados;
using AmbienteEscolar.Business.Classes;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

namespace AmbienteEscolar.Business.Repositorios
{
    public class ProfessorRepository
    {
        Banco banco = new Banco();

        public static List<Professor> ListarProfessores()
        {
            //StringBuilder sb = new StringBuilder();

            //sb.AppendLine("SELECT p.id, p.nome, p.email, p.id_curso, c.descricao, c.turno FROM professor p");
            //sb.AppendLine("INNER JOIN curso c ON p.id_curso = c.id;");

            //List<Professor> listaProfessores = new List<Professor>();

            //if (BancoDados.OpenConnection() == true)
            //{
            //    MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.Connection);
            //    MySqlDataReader dataReader = cmd.ExecuteReader();

            //    while (dataReader.Read())
            //    {
            //        Curso curso = new Curso();
            //        Professor professor = new Professor();

            //        professor.Id = int.Parse(dataReader["id"].ToString());
            //        professor.Nome = dataReader["nome"].ToString();
            //        professor.Email = dataReader["email"].ToString();

            //        curso.Id = int.Parse(dataReader["id_curso"].ToString());
            //        curso.Descricao = dataReader["descricao"].ToString();
            //        curso.Turno = dataReader["turno"].ToString();

            //        professor.Curso = curso;

            //        listaProfessores.Add(professor);
            //    }
            //    dataReader.Close();
            //    BancoDados.CloseConnection();

            //    return listaProfessores;
            //}
            //else
            //{
            //    return listaProfessores;
            //}
            return new List<Professor>();
        }

        public static bool InserirProfessor(string nome, string email, int id_curso)
        {
            string query = "INSERT INTO professor (nome, email, id_curso) VALUES('" + nome + "','" + email + "'," + id_curso + ");";

            if (BancoDados.OpenConnection() == true)
            {
                MySqlConnection connection = new MySqlConnection();
                MySqlCommand cmd = new MySqlCommand(query, BancoDados.Connection);

                cmd.ExecuteNonQuery();

                BancoDados.CloseConnection();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AtualizarProfessor(int id, string nome, string email, int id_curso)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE professor SET");
            sb.AppendLine("nome='" + nome + "',");
            sb.AppendLine("email='" + email + "',");
            sb.AppendLine("id_curso='" + id_curso + "'");
            sb.AppendLine("WHERE id='" + id + "'");

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.Connection);

                cmd.ExecuteNonQuery();

                BancoDados.CloseConnection();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeletarProfessor(int id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DELETE FROM professor WHERE id=" + id + "");

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.Connection);

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