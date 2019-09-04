using System;
using System.Collections.Generic;
using System.Linq;

namespace Compilador
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader fr = new FileReader();
            string content = fr.ReadFile(@"C:\Users\alu201617770\Desktop", "program.lpd");

            if (!string.IsNullOrEmpty(content))
            {
                Analisador a = new Analisador(content);
                List<Token> tokens = a.Analisar();
                Console.WriteLine("qtd de tokens {0}", tokens.Count);
                tokens.ForEach(x => Console.WriteLine(x.ToString()));
            }
        }
    }
}
