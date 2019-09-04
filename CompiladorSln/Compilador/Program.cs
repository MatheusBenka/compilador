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
            FileReader fr = new FileReader();
            string fPath = Path.Combine(@"C:\Users\alu201617770\Desktop", "program.lpd");            

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
