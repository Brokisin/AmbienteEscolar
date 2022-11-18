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
    public class MatriculaRepository
    {
        public static List<Matricula> ListarMatriculas(int id)
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("SELECT * FROM curso");
            sb.AppendLine("SELECT m.id, m.numero_matricula, m.id_aluno, a.nome, a.email, a.id_curso, c.descricao, c.turno FROM matricula m "); //mysql
            sb.AppendLine("INNER JOIN aluno a ON m.id_aluno = a.id INNER JOIN curso c ON a.id_curso = c.id WHERE a.id=" + id + ";");

            List<Matricula> listaMatriculas = new List<Matricula>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Matricula matr = new Matricula();
                    Aluno aluno = new Aluno();
                    Curso curso = new Curso();

                    matr.Id = int.Parse(dataReader["id"].ToString());
                    matr.Numero_matricula = dataReader["numero_matricula"].ToString();

                    aluno.Id = int.Parse(dataReader["id_aluno"].ToString());
                    aluno.Nome = dataReader["nome"].ToString();
                    aluno.Email = dataReader["email"].ToString();

                    curso.Id = int.Parse(dataReader["id_curso"].ToString());
                    curso.Descricao = dataReader["descricao"].ToString();
                    curso.Turno = dataReader["turno"].ToString();

                    matr.Aluno = aluno;
                    aluno.Curso = curso;

                    listaMatriculas.Add(matr);
                }
                dataReader.Close();
                BancoDados.CloseConnection();

                return listaMatriculas;
            }
            else
            {
                return listaMatriculas;
            }
        }

        public static bool InserirMatricula(int id_aluno)
        {
            int rndRegister = 0;
            Random rnd = new Random();

            for (int j = 0; j < 1; j++)
            {
                rndRegister = rnd.Next();
            }

            string query = "INSERT INTO matricula (numero_matricula, id_aluno) VALUES('" + rndRegister + "','" + id_aluno + "');";

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