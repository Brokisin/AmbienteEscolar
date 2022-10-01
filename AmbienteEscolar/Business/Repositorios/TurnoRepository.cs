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
    public class TurnoRepository
    {
        public static List<Turno> ListarTurnos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT * FROM turno");
            sb.AppendLine("ORDER BY id;");

            List<Turno> listaTurnos = new List<Turno>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Turno turno = new Turno();

                    turno.Id = int.Parse(dataReader["id"].ToString());
                    turno.Descricao = dataReader["descricao"].ToString();

                    listaTurnos.Add(turno);
                }
                dataReader.Close();
                BancoDados.CloseConnection();

                return listaTurnos;
            }
            else
            {
                return listaTurnos;
            }
        }
    }
}