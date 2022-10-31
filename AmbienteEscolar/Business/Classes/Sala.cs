using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbienteEscolar.Business.Classes
{
    public class Sala
    {
        public int Id { get; set; }
        public int Numero_sala { get; set; }
        public string Bloco { get; set; }
        public int Capacidade { get; set; }
    }
}