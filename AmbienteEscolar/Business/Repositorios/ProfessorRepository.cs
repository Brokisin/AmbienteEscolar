using AmbienteEscolar.Business.BancoDeDados;
using AmbienteEscolar.Business.Classes;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbienteEscolar.Business.Repositorios
{
    public class ProfessorRepository
    {
        Banco banco = new Banco();

        public static List<String> BuscarNomeProfessores()
        {
            List<string> alunos = new List<string>();

            string query = "SELECT nome FROM professor ORDER BY id;";

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



        public static List<string>[] ListarProfessores()
        {
            List<string> listaProfessores = new List<string>();

            string query = "SELECT * FROM professor";

            List<string>[] professor = new List<string>[3];
            professor[0] = new List<string>();
            professor[1] = new List<string>();
            professor[2] = new List<string>();
            professor[3] = new List<string>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    professor[0].Add(dataReader["id"] + "");
                    professor[1].Add(dataReader["nome"] + "");
                    professor[2].Add(dataReader["email"] + "");
                    professor[3].Add(dataReader["id_curso"] + "");
                }
                dataReader.Close();
                BancoDados.CloseConnection();

                return professor;
            }
            else
            {
                return professor;
            }
        }




            //StringBuilder construcaoSelect = new ();
            //ConexaoSQL sql = new ();
            //SqlConnection conexaosql = null;
            //List<Funcionario> listaFuncionario = new ();

            //construcaoSelect.AppendLine("SELECT *");
            //construcaoSelect.AppendLine("FROM Funcionario");
            //if (id > 0)
            //{
            //    construcaoSelect.AppendLine("WHERE id = " + id);
            //}
            //    construcaoSelect.AppendLine("ORDER BY id");

            //try
            //{
            //    conexaosql = sql.CriarConexaoRSO();
            //    conexaosql.Open();

            //    SqlCommand comando = new SqlCommand(construcaoSelect.ToString(), conexaosql);

            //    using (SqlDataReader leitor = comando.ExecuteReader())
            //    {
            //        if (leitor.HasRows)
            //        {
            //            while (leitor.Read())
            //            {
            //                Funcionario funcionario = new Funcionario();
            //                Funcao funcao = new Funcao();

            //                funcionario.id = int.Parse(leitor["id"].ToString());
            //                funcionario.ativo = bool.Parse(leitor["ativo"].ToString());
            //                funcionario.nome = leitor["nome"].ToString();
            //                funcionario.email = (leitor["email"].ToString());
            //                funcionario.telefone = (leitor["telefone"].ToString());
            //                funcionario.id = int.Parse(leitor["id_funcao"].ToString());

            //                //funcionario.funcao = (funcao);
            //                listaFuncionario.Add(funcionario);
            //            }
            //        }
            //    }
            //}
    }
}