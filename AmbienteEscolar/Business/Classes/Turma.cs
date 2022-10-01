using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbienteEscolar.Business.Classes
{
    public class Turma
    {
        public int Id { get; set; }
        public int Numero_turma { get; set; }
        public int Id_turno { get; set; }
        public int Id_sala { get; set; }
    }
}