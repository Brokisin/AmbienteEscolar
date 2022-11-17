using AmbienteEscolar.Business.Classes.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbienteEscolar.Business.Classes
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int Id_professor { get; set; }
        public int Id_aluno { get; set; }
        public int Id_curso { get; set; }
        public NivelAcesso NivelAcesso { get; set; }
        public int Ativo { get; set; }
    }
}