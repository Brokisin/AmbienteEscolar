using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbienteEscolar.Business.Classes
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Curso Curso { get; set; }
    }
}