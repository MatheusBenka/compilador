using System;
using System.Collections.Generic;
using System.Text;

namespace Compilador
{
    public class Analisador
    {
        private readonly string _content;
        private List<Token> lt = new List<Token>();
        public Analisador(string content)
        {
            _content = content;
        }

        public List<Token> Analisar()
        {

            return this.lt;
        }
    }
}
