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
    public class CursoRepository
    {
        public static List<Curso> ListarCursos()
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("SELECT * FROM curso");
            sb.AppendLine("SELECT * FROM curso"); //mysql
            sb.AppendLine("ORDER BY descricao;");

            List<Curso> listaCursos = new List<Curso>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Curso curso = new Curso();

                    curso.Id = int.Parse(dataReader["id"].ToString());
                    curso.Descricao = dataReader["descricao"].ToString();
                    curso.Turno = dataReader["turno"].ToString();

                    listaCursos.Add(curso);
                }
                dataReader.Close();
                BancoDados.CloseConnection();

                return listaCursos;
            }
            else
            {
                return listaCursos;
            }
        }

        public static List<Curso> ListarNomeCursos()
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("SELECT descricao FROM curso");
            sb.AppendLine("SELECT descricao FROM curso"); //mysql
            sb.AppendLine("ORDER BY id;");

            List<Curso> listaCursos = new List<Curso>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Curso curso = new Curso();

                    curso.Id = int.Parse(dataReader["id"].ToString());
                    curso.Descricao = dataReader["descricao"].ToString();
                    //curso.Id_turno = int.Parse(dataReader["turno"].ToString());

                    listaCursos.Add(curso);
                }
                dataReader.Close();
                BancoDados.CloseConnection();

                return listaCursos;
            }
            else
            {
                return listaCursos;
            }
        }

        public static int ListarCursosDescricao(string descricao)
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("SELECT * FROM curso");
            sb.AppendLine("SELECT * FROM curso"); //mysql
            sb.AppendLine("WHERE descricao like '%" + descricao + "%' ORDER BY descricao;");
            
            Curso curso = new Curso();
            List<Curso> listaCursos = new List<Curso>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    curso.Id = int.Parse(dataReader["id"].ToString());
                    curso.Descricao = "";
                    curso.Turno = "";

                    listaCursos.Add(curso);
                }
                dataReader.Close();
                BancoDados.CloseConnection();

                return curso.Id;
            }
            else
            {
                return curso.Id;
            }
        }

        public static void InserirCurso(string descricao, string turno)
        {
            //string query = "INSERT INTO curso (descricao, turno) VALUES('" + descricao + "','" + turno + "');"; //php
            string query = "INSERT INTO curso (descricao, turno) VALUES('" + descricao + "', '" + turno + "');"; //mysql

            if (BancoDados.OpenConnection() == true)
            {
                MySqlConnection connection = new MySqlConnection();
                MySqlCommand cmd = new MySqlCommand(query, BancoDados.connection);

                cmd.ExecuteNonQuery();

                BancoDados.CloseConnection();
            }
        }

        public static void DeletarCurso(int id)
        {
            //string query = "DELETE FROM curso WHERE id=" + id + "";
            string query = "DELETE FROM cursos WHERE id=" + id + ""; //mysql

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