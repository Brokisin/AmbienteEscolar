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
    public class NivelAcessoRepository
    {
        public static List<NivelAcesso> ListarAcesso()
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("SELECT id, descricao FROM nivelacesso ORDER BY id;");
            sb.AppendLine("SELECT id, descricao FROM nivelAcesso ORDER BY id;");

            List<NivelAcesso> listaNivelAcesso = new List<NivelAcesso>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    NivelAcesso na = new NivelAcesso();

                    na.Id = int.Parse(dataReader["id"].ToString());
                    na.Descricao = dataReader["descricao"].ToString();

                    listaNivelAcesso.Add(na);
                }
                dataReader.Close();
                BancoDados.CloseConnection();

                return listaNivelAcesso;
            }
            else
            {
                return listaNivelAcesso;
            }
        }

        public static int ListarAcessosDescricao(string descricao)
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("SELECT * FROM curso");
            sb.AppendLine("SELECT * FROM nivelAcesso"); //mysql
            sb.AppendLine("WHERE descricao like '%" + descricao + "%' ORDER BY descricao;");

            NivelAcesso na = new NivelAcesso();
            List<NivelAcesso> listaAcessos = new List<NivelAcesso>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    na.Id = int.Parse(dataReader["id"].ToString());
                    na.Descricao = "";

                    listaAcessos.Add(na);
                }
                dataReader.Close();
                BancoDados.CloseConnection();

                return na.Id;
            }
            else
            {
                return na.Id;
            }
        }
    }
}