using AmbienteEscolar.Business.BancoDeDados;
using AmbienteEscolar.Business.Classes;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT id, nome, registro, cpf, email FROM ava_db.professor;");
            List<Professor> listaProfessores = new List<Professor>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Professor professor = new Professor();

                    professor.Id = int.Parse(dataReader["id"].ToString());
                    professor.Nome = dataReader["nome"].ToString();
                    professor.Registro = dataReader["registro"].ToString();
                    professor.Cpf = dataReader["cpf"].ToString();
                    professor.Email = dataReader["email"].ToString();

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

        public static bool InserirProfessor(string nome, string registro, string cpf, string email)
        {
            string query = $"INSERT INTO professor (nome, registro, cpf, email) VALUES('{nome}', '{registro}', '{cpf}', '{email}');";

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

        public static bool AtualizarProfessor(int id, string nome, string registro, string cpf, string email)
        {
            StringBuilder sb = new StringBuilder();

            string query = $"UPDATE professor SET nome='{nome}', registro='{registro}', cpf='{cpf}', email='{email}' WHERE id={id}";

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.Connection);
                cmd.ExecuteNonQuery();
                BancoDados.CloseConnection();
                return true;
            }
            else
                return false;
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