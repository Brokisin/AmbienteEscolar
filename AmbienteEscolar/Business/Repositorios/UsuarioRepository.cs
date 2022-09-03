using AmbienteEscolar.Business.BancoDeDados;
using AmbienteEscolar.Business.Classes;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbienteEscolar.Business.Repositorios
{
    public class UsuarioRepository
    {
        Banco banco = new Banco();

        public static List<String>[] BuscarLogin()
        {
            List<string> listaLogin = new List<string>();

            string query = "SELECT login, senha FROM usuario;";

            List<string>[] login = new List<string>[1];
            login[0] = new List<string>();
            login[1] = new List<string>();

            try
            {
                if (BancoDados.OpenConnection() == true)
                {
                    MySqlCommand command = new MySqlCommand(query, BancoDados.connection);
                    MySqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            login[0].Add(dataReader["nome"] + "");
                            login[1].Add(dataReader["senha"] + "");
                        }
                        dataReader.Close();
                        BancoDados.CloseConnection();

                        return login;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return login;
        }


        public static List<string>[] ListarAlunos()
        {
            List<string> listaAlunos = new List<string>();

            string query = "SELECT * FROM aluno";

            List<string>[] aluno = new List<string>[3];
            aluno[0] = new List<string>();
            aluno[1] = new List<string>();
            aluno[2] = new List<string>();
            aluno[3] = new List<string>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    aluno[0].Add(dataReader["id"] + "");
                    aluno[1].Add(dataReader["nome"] + "");
                    aluno[2].Add(dataReader["email"] + "");
                    aluno[3].Add(dataReader["id_curso"] + "");
                }
                dataReader.Close();
                BancoDados.CloseConnection();

                return aluno;
            }
            else
            {
                return aluno;
            }
        }

    }
}