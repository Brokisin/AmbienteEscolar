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

        public static List<String> BuscarAlunos()
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

        public static List<string>[] ListarAlunos()
        {
            List<string> listaAlunos = new List<string>();

            string query = "SELECT * FROM aluno";
            
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            
            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["nome"] + "");
                    list[2].Add(dataReader["email"] + "");
                    list[3].Add(dataReader["id_curso"] + "");
                }
                dataReader.Close();
                BancoDados.CloseConnection();
                
                return list;
            }
            else
            {
                return list;
            }
        }

        public static void InserirAluno(string nome, string email, int id_acesso)
        {
            string query = "INSERT INTO Pessoa (nome, sobrenome) VALUES('" + nome + "','" + email + "'," + id_acesso + ");";
            
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