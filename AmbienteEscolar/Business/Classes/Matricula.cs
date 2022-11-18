using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbienteEscolar.Business.Classes
{
    public class Matricula
    {
        public int Id { get; set; }
        public string Numero_matricula { get; set; }
        public Aluno Aluno { get; set; }
    }
}