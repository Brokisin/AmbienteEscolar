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

            sb.AppendLine("SELECT * FROM professor");
            sb.AppendLine("ORDER BY id;");

            List<Professor> listaProfessores = new List<Professor>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Professor professor = new Professor();

                    professor.Id = int.Parse(dataReader["id"].ToString());
                    professor.Nome = dataReader["nome"].ToString();
                    professor.Email = dataReader["email"].ToString();
                    professor.Id_curso = int.Parse(dataReader["id_curso"].ToString());

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
    }
}