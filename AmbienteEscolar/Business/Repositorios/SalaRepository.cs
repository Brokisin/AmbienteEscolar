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
    public class SalaRepository
    {
        public static List<Sala> ListarAlunos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT s.id, s.numero_sala, s.bloco, s.capacidade, c.descricao, c.turno FROM sala ");
            sb.AppendLine("INNER JOIN curso c ON a.id_curso = c.id;");

            List<Sala> listaAlunos = new List<Sala>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.Connection);
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
                    aluno.Curso = curso;

                    //listaAlunos.Add(aluno);
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
    }
}