using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbienteEscolar.Business.Classes
{
    public class Curso
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Turno Turno { get; set; }
    }
}