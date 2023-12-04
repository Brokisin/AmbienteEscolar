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
        public string Cpf { get; set; }
        public int Matricula { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Curso Curso { get; set; }
        public Dictionary<int, List<Disciplina>> DisciplinasPorModulo;
        public List<Disciplina> ListaDisciplinas { get; set; }
    }
}