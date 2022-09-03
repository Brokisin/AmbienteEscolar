﻿using AmbienteEscolar.Business.BancoDeDados;
using AmbienteEscolar.Business.Classes;
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

            sb.AppendLine("SELECT * FROM usuario");
            sb.AppendLine("ORDER BY id;");

            List<Usuario> listaUsuarios = new List<Usuario>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = int.Parse(dataReader["id"].ToString());
                    usuario.Login = dataReader["login"].ToString();
                    usuario.Senha = dataReader["senha"].ToString();
                    usuario.Id_professor = int.Parse(dataReader["id_professor"].ToString());
                    usuario.Id_aluno = int.Parse(dataReader["id_aluno"].ToString());
                    usuario.Id_curso = int.Parse(dataReader["id_curso"].ToString());
                    usuario.Id_acesso = int.Parse(dataReader["id_acesso"].ToString());
                    usuario.Ativo = int.Parse(dataReader["ativo"].ToString());

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

    }
}