﻿using AmbienteEscolar.Business.BancoDeDados;
using AmbienteEscolar.Business.Classes;
using AmbienteEscolar.Business.Classes.Enum;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static List<Usuario> ListarUsuarios()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT a.id, a.login, a.senha, a.id_acesso, n.descricao FROM ambienteescolarava.usuario a ");
            sb.AppendLine("INNER JOIN nivelacesso n ON a.id_acesso = n.id ORDER BY id;");

            List<Usuario> listaUsuarios = new List<Usuario>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Usuario usuario = new Usuario();
                    NivelAcesso na = new NivelAcesso();

                    usuario.Id = int.Parse(dataReader["id"].ToString());
                    usuario.Login = dataReader["login"].ToString();
                    usuario.Senha = dataReader["senha"].ToString();

                    usuario.Id_professor = 0;
                    usuario.Id_aluno = 0;

                    na.Id = int.Parse(dataReader["id_acesso"].ToString());
                    na.Descricao = dataReader["descricao"].ToString();
                    usuario.NivelAcesso = na;

                    listaUsuarios.Add(usuario);
                }
                dataReader.Close();
                BancoDados.CloseConnection();

                return listaUsuarios;
            }
            else
            {
                return listaUsuarios;
            }
        }

        public static bool Login(string login, string senha)
        {
            //string query = "SELECT Count(*) FROM usuario WHERE login='" + login + "' AND senha='" + senha + "';";
            string query = "SELECT count(*) FROM ambienteescolarava.usuario WHERE login='" + login + "' and senha='" + senha + "'";

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, BancoDados.connection);
                try
                {
                    int count = int.Parse(cmd.ExecuteScalar() + "");
                    BancoDados.CloseConnection();
                    
                    if (count > 0)
                    {
                        return true;
                    }
                    return false;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Algo deu errado. Tente novamente.");
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}