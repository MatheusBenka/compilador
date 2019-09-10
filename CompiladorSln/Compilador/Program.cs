using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Compilador
{
    class Program
    {
        static void Main(string[] args)
        {            
            string pathArquivo = string.Empty;
            string fPath = Path.Combine(pathArquivo, "program.lpd");            

            if (!string.IsNullOrEmpty(fPath))
            {
                Analisador a = new Analisador(fPath);
                List<Token> tokens = a.Analisar();
                Console.WriteLine("qtd de tokens {0}", tokens.Count);
                tokens.ForEach(x => Console.WriteLine(x.ToString()));
            }
        }
    }
}
