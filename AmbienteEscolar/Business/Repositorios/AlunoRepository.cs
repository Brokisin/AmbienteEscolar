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

            //sb.AppendLine("SELECT a.id, a.nome, a.email, a.id_curso, c.descricao, c.turno FROM aluno a ");
            sb.AppendLine("SELECT a.id, a.nome, a.email, a.id_curso, c.descricao, c.turno FROM ambienteescolarava.aluno a ");
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

        public static List<Aluno> ListarAlunosPorNome()
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("SELECT a.id, a.nome, a.email, a.id_curso, c.descricao, c.turno FROM aluno a");
            sb.AppendLine("SELECT a.id, a.nome, a.email, a.id_curso, c.descricao, c.turno FROM ambienteescolarava.aluno a");
            sb.AppendLine("INNER JOIN curso c ON a.id_curso = c.id ORDER BY a.nome DESC;");

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

        public static List<Aluno> ListarAlunosPorEmail()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT a.id, a.nome, a.email, a.id_curso, c.descricao, c.turno FROM aluno a ");
            sb.AppendLine("INNER JOIN curso c ON a.id_curso = c.id ORDER BY a.email DESC;");

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

        public static bool AtualizarAluno(int id, string nome, string email, int id_curso)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE aluno SET");
            sb.AppendLine("nome='" + nome + "',");
            sb.AppendLine("email='" + email + "',");
            sb.AppendLine("id_curso='" + id_curso + "'");
            sb.AppendLine("WHERE id='" + id + "'");

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.connection);

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