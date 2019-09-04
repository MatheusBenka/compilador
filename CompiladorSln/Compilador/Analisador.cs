using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Compilador
{
    public class Analisador
    {
        private readonly string _path;
        
        private List<Token> lt = new List<Token>();
        public Analisador(string path)
        {
            _path = path;
        }

        public List<Token> Analisar()
        {
            int intch = 0;
            int linha = 1;
            int coluna = 0;
            using (FileStream fr = new FileStream(_path,FileMode.Open,FileAccess.ReadWrite))
            {
                while((intch = fr.ReadByte()) != -1)
                {
                    char a = (char)intch;
                    coluna++;
                    if (Char.IsLetter(a))
                    {
                        Console.WriteLine("{0} é letra", a);
                    }

                    if(a == '\n') // final de linha
                    {
                        linha++;
                        Console.WriteLine("nova linha");
                    }
                }
            }
            return this.lt;
        }
    }
}
