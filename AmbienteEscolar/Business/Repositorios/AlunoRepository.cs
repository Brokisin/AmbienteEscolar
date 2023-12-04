using AmbienteEscolar.Business.BancoDeDados;
using AmbienteEscolar.Business.Classes;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmbienteEscolar.Business.Repositorios
{
    public class AlunoRepository
    {
        Banco banco = new Banco();

        public static List<Aluno> ListarAlunos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT id, nome, cpf, matricula, telefone, email FROM aluno");

            List<Aluno> listaAlunos = new List<Aluno>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Aluno aluno = new Aluno();

                    aluno.Id = int.Parse(dataReader["id"].ToString());
                    aluno.Nome = dataReader["nome"].ToString();
                    aluno.Cpf = dataReader["cpf"].ToString();
                    aluno.Matricula = int.Parse(dataReader["matricula"].ToString());
                    aluno.Telefone = dataReader["telefone"].ToString();
                    aluno.Email = dataReader["email"].ToString();
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

        public static Aluno BuscarAlunoPorMatricula(int matricula)
        {
            Aluno aluno = new Aluno();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"SELECT id, nome, cpf, matricula, telefone, email FROM aluno WHERE matricula='{matricula}'");
            try
            {
                if (BancoDados.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.Connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        aluno.Id = int.Parse(dataReader["id"].ToString());
                        aluno.Nome = dataReader["nome"].ToString();
                        aluno.Cpf = dataReader["cpf"].ToString();
                        aluno.Matricula = int.Parse(dataReader["matricula"].ToString());
                        aluno.Telefone = dataReader["telefone"].ToString();
                        aluno.Email = dataReader["email"].ToString();
                    }
                    dataReader.Close();
                    BancoDados.CloseConnection();

                    return aluno;
                }
                else { return aluno; }
            }
            catch (Exception e)
            {
                return aluno = null;
            }
        }

        public static bool InserirAluno(string nome, int matricula, string cpf, string telefone, string email)
        {
            string query = $"INSERT INTO aluno (nome, cpf, matricula, telefone, email) VALUES('{nome}', {cpf}, '{matricula}', '{telefone}', '{email}');";

            if (BancoDados.OpenConnection() == true)
            {
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

        public static bool AtualizarAluno(int id, string nome, int matricula, string cpf, string telefone, string email)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE aluno SET");
            sb.AppendLine("nome='" + nome + "',");
            sb.AppendLine("cpf='" + cpf + "',");
            sb.AppendLine("matricula='" + matricula + "',");
            sb.AppendLine("telefone='" + telefone + "',");
            sb.AppendLine("email='" + email + "'");
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

        public static bool DeletarAluno(int id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DELETE FROM aluno WHERE id=" + id + "");

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