using System;
using System.Collections.Generic;
using System.Text;

namespace Compilador
{
    public class Token
    {
        public Enums.EnumTipos Tipo { get; set; }
        public string Lexema { get; set; }
        public string Linha { get; set; }
        public string Coluna { get; set; }

        public string ToString()
        {
            return string.Format("Tipo {0} Lex: {1}, Linha: {2} Coluna: {3}", this.Tipo.ToString(), this.Lexema,this.Linha,this.Coluna);
        }
    }
}
