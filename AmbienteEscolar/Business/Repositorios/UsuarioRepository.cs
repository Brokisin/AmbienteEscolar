using AmbienteEscolar.Business.BancoDeDados;
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

        public static Usuario BuscarLogin(string loginUser)
        {
            string query = $"SELECT a.id, a.login, a.senha, a.id_nivel_acesso, n.descricao FROM usuario a " +
                $"INNER JOIN nivel_acesso n ON a.id_nivel_acesso = n.id WHERE login='{loginUser}' ORDER BY n.id;";

            Usuario login = new Usuario();
            login.NivelAcesso = new NivelAcesso();
            try
            {
                BancoDados.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, BancoDados.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        login.Login = dataReader["login"].ToString();
                        login.Senha = dataReader["senha"].ToString();
                        login.NivelAcesso.Id = int.Parse(dataReader["id_nivel_acesso"].ToString());
                    }
                    dataReader.Close();
                    BancoDados.CloseConnection();

                    return login;
                }
                else { return login = null; }
            }
            catch (Exception) { return login = null; }
        }

        public static List<Usuario> ListarUsuarios()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT a.id, a.login, a.senha, a.id_nivel_acesso, n.descricao FROM usuario a");
            sb.AppendLine("INNER JOIN nivel_acesso n ON a.id_nivel_acesso = n.id ORDER BY n.id;");

            List<Usuario> listaUsuarios = new List<Usuario>();
            try
            {
                BancoDados.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = int.Parse(dataReader["id"].ToString());
                    usuario.Login = dataReader["login"].ToString();
                    usuario.Senha = dataReader["senha"].ToString();

                    NivelAcesso na = new NivelAcesso();
                    na.Id = int.Parse(dataReader["id_nivel_acesso"].ToString());
                    na.Descricao = dataReader["descricao"].ToString();

                    usuario.NivelAcesso = na;

                    listaUsuarios.Add(usuario);
                }
                dataReader.Close();

                return listaUsuarios;
            }
            catch (Exception) { return listaUsuarios; }
            finally { BancoDados.CloseConnection(); }
        }

        public static bool Login(string login, string senha)
        {
            string query = "SELECT count(*) FROM usuario WHERE login='" + login + "' and senha='" + senha + "'";

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, BancoDados.Connection);
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

        public static Sessao BuscarSessao(string login)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"SELECT nome, matricula FROM aluno WHERE matricula='{login}'");

            Sessao sessao = null;
            NivelAcesso na = null;
            try
            {
                BancoDados.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (!dataReader.HasRows)
                {
                    return sessao = BuscarSessaoProfessor(login);
                }

                sessao = new Sessao();
                sessao.Nome = dataReader["nome"].ToString();
                sessao.Matricula = int.Parse(dataReader["matricula"].ToString());
                dataReader.Close();

                sb = new StringBuilder();
                sb.AppendLine("SELECT id_nivel_acesso, n.descricao FROM usuario a");
                sb.AppendLine($"INNER JOIN nivel_acesso n ON a.id_nivel_acesso = n.id WHERE login='{login}' ORDER BY n.id;");

                cmd = new MySqlCommand(sb.ToString(), BancoDados.Connection);
                dataReader = cmd.ExecuteReader();
                dataReader.Read();

                if (!dataReader.HasRows)
                {
                    na = null;
                }
                else
                {
                    na = new NivelAcesso();
                    na.Id = int.Parse(dataReader["id_nivel_acesso"].ToString());
                    na.Descricao = dataReader["descricao"].ToString();
                }

                sessao.NivelAcesso = na;

                dataReader.Close();
                return sessao;
            }
            catch (Exception) { return sessao; }
            finally { BancoDados.CloseConnection(); }
        }

        public static Sessao BuscarSessaoProfessor(string login)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"SELECT nome, registro FROM professor WHERE registro='{login}'");

            Sessao sessao = null;
            NivelAcesso na = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (!dataReader.HasRows)
                {
                    return sessao;
                }

                sessao = new Sessao();
                sessao.Nome = dataReader["nome"].ToString();
                sessao.Registro = dataReader["registro"].ToString();
                dataReader.Close();

                sb = new StringBuilder();
                sb.AppendLine("SELECT id_nivel_acesso, n.descricao FROM usuario a");
                sb.AppendLine($"INNER JOIN nivel_acesso n ON a.id_nivel_acesso = n.id WHERE login='{login}' ORDER BY n.id;");

                cmd = new MySqlCommand(sb.ToString(), BancoDados.Connection);
                dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (!dataReader.HasRows)
                {
                    na = null;
                }
                else
                {
                    na = new NivelAcesso();
                    na.Id = int.Parse(dataReader["id_nivel_acesso"].ToString());
                    na.Descricao = dataReader["descricao"].ToString();
                }

                sessao.NivelAcesso = na;

                dataReader.Close();
                return sessao;
            }
            catch (Exception) { return sessao; }
            finally { BancoDados.CloseConnection(); }
        }

        public static bool InserirUsuario(string login, string senha, int idAcesso)
        {
            string query = "INSERT INTO usuario (login, senha, id_nivel_acesso) VALUES('" + login + "','" + senha + "'," + idAcesso + ");";

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

        public static bool AtualizarUsuario(int id, string login, string senha, int idAcesso)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE usuario SET");
            sb.AppendLine("login='" + login + "',");
            sb.AppendLine("senha='" + senha + "',");
            sb.AppendLine("id_nivel_acesso='" + idAcesso + "'");
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

        public static bool DeletarUsuario(int id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DELETE FROM usuario WHERE id=" + id + "");

            try
            {
                if (BancoDados.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.Connection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e) { return false; }
            finally { BancoDados.CloseConnection(); }
        }

        public static bool DeletarUsuarioPorLogin(string login)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DELETE FROM usuario WHERE login='" + login + "'");
            try
            {
                if (BancoDados.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.Connection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e) { return false; }
            finally { BancoDados.CloseConnection(); }
        }
    }
}