using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbienteEscolar.Business.Repositorios
{
    public class ProfessorRepository
    {


        StringBuilder construcaoSelect = new();
        ConexaoSQL sql = new();
        SqlConnection conexaosql = null;
        List<Funcionario> listaFuncionario = new();

        construcaoSelect.AppendLine("SELECT *");
            construcaoSelect.AppendLine("FROM Funcionario");
            if (id > 0)
            {
                construcaoSelect.AppendLine("WHERE id = " + id);
            }
    construcaoSelect.AppendLine("ORDER BY id");

            try
            {
                conexaosql = sql.CriarConexaoRSO();
                conexaosql.Open();

                SqlCommand comando = new SqlCommand(construcaoSelect.ToString(), conexaosql);

                using (SqlDataReader leitor = comando.ExecuteReader())
                {
                    if (leitor.HasRows)
                    {
                        while (leitor.Read())
                        {
                            Funcionario funcionario = new Funcionario();
    Funcao funcao = new Funcao();

    funcionario.id = int.Parse(leitor["id"].ToString());
    funcionario.ativo = bool.Parse(leitor["ativo"].ToString());
    funcionario.nome = leitor["nome"].ToString();
    funcionario.email = (leitor["email"].ToString());
                            funcionario.telefone = (leitor["telefone"].ToString());
                            funcionario.id = int.Parse(leitor["id_funcao"].ToString());

    //funcionario.funcao = (funcao);
    listaFuncionario.Add(funcionario);
                        }
                    }
                }
            }
    }
}