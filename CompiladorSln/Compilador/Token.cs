using System;
using System.Collections.Generic;
using System.Text;

namespace Compilador
{
    public class Token
    {
        public Enums.EnumTipos Simbolo { get; set; }
        public string Lexema { get; set; }
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public string ToString()
        {
            return string.Format("Simbolo {0} Lex: {1}, Linha: {2} Coluna: {3}", this.Simbolo.ToString(), this.Lexema,this.Linha,this.Coluna);
        }
    }
}
