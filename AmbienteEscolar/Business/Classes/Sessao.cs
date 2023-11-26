using AmbienteEscolar.Business.Classes.Enum;
using System.Web;
using System.Web.Helpers;

namespace AmbienteEscolar.Business.Classes
{
    public class Sessao
    {
        public string Nome { get; set; }
        public string Registro { get; set; } = "";
        public int Matricula { get; set; } = 0;
        public NivelAcesso NivelAcesso { get; set; }

        private static string _nomeCookie { get; set; }

        public static Sessao Current()
        {
            _nomeCookie = "UserLogin";

            HttpCookie httpCookie = HttpContext.Current.Request.Cookies[_nomeCookie];
            Sessao sessao = null;
            NivelAcesso na = null;
            if (httpCookie != null)
            {
                sessao = new Sessao();
                string cookieValue = httpCookie.Value;
                string[] cookieSeparado = cookieValue.Split(',');
                sessao.Nome = cookieSeparado[0];
                sessao.Matricula = int.Parse(cookieSeparado[1]);
                sessao.Registro = cookieSeparado[2];
                na = new NivelAcesso();
                na.Id = int.Parse(cookieSeparado[3]);
                na.Descricao = cookieSeparado[4];
                sessao.NivelAcesso = na;
            }

            return sessao == null ? new Sessao() : sessao;
        }
    }
}
