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
        private List<char> operadores = new List<char>() { '+', '-', '*'};                
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
                    if (Char.IsWhiteSpace(a) || a == '/') { continue; } // tratar espaços
                    
                    Token t = PegaToken(fr, a, linha, coluna);

                    if (t == null || t.Simbolo == Enums.EnumTipos.SERRO)
                    {
                        return this.lt;
                    }
                    else
                    {
                        this.lt.Add(t);
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

        private Token PegaToken(FileStream fr, char c,int linha, int coluna)
        {
            if (Char.IsDigit(c)) // tratar digito
            {                
                string num = c.ToString();
                char b = (char)fr.ReadByte();

                while (Char.IsDigit(b))
                {
                    num = string.Concat(num, b);
                }
                return new Token()
                {
                    Coluna = coluna,
                    Linha = linha,
                    Lexema = num,
                    Simbolo = Enums.EnumTipos.SNUMERO
                };      
            }

            if (Char.IsLetter(c))//trata identificador e palavra reservada
            {
                
                string palavra = c.ToString();
                char b = (char)fr.ReadByte();

                while (Char.IsLetterOrDigit(b) || b == '_')
                {
                    palavra = string.Concat(palavra, b);
                }

                switch (palavra)
                {
                    case "var":
                        return new Token()
                        {
                            Simbolo = Enums.EnumTipos.SVAR,
                            Lexema = palavra,
                            Linha = linha,
                            Coluna = coluna
                        };
                    case "inicio":
                        return new Token()
                        {
                            Simbolo = Enums.EnumTipos.SINICIO,
                            Lexema = palavra,
                            Linha = linha,
                            Coluna = coluna
                        };
                    case "fim":
                        return new Token()
                        {
                            Simbolo = Enums.EnumTipos.SNUMERO,
                            Lexema = palavra,
                            Linha = linha,
                            Coluna = coluna
                        };
                    case "escreva":
                        return new Token()
                        {
                            Simbolo = Enums.EnumTipos.SESCREVA,
                            Lexema = palavra,
                            Linha = linha,
                            Coluna = coluna
                        };
                    case "inteiro":
                        return new Token()
                        {
                            Simbolo = Enums.EnumTipos.SINTEIRO,
                            Lexema = palavra,
                            Linha = linha,
                            Coluna = coluna
                        };
                    default:
                        return new Token()
                        {
                            Simbolo = Enums.EnumTipos.SIDENTIFICADOR,
                            Lexema = palavra,
                            Linha = linha,
                            Coluna = coluna
                        };
                }             
            }

            if(c == '.') // 
            {
                return new Token()
                {
                    Coluna = coluna,
                    Linha = linha,
                    Lexema = c.ToString(),
                    Simbolo = Enums.EnumTipos.SPONTO

                };
            }

            if(c == ':')
            {
                char m = (char)fr.ReadByte();
                if(m == '=')
                {
                    return new Token()
                    {
                        Coluna = coluna,
                        Linha = linha,
                        Lexema = c.ToString(),
                        Simbolo = Enums.EnumTipos.SATRIBUICAO

                    };
                }
                else
                {
                    return new Token()
                    {
                        Coluna = coluna,
                        Linha = linha,
                        Lexema = c.ToString(),
                        Simbolo = Enums.EnumTipos.SDOISPONTOS

                    };
                }
                
            }

            if (operadores.Contains(c))
            {                
                // trata operacoes
                switch (c)
                {
                    case '+' : return new Token() { Coluna = coluna, Linha = linha, Lexema = c.ToString(), Simbolo = Enums.EnumTipos.SMAIS};
                    case '-' : return new Token() { Coluna = coluna, Linha = linha, Lexema = c.ToString(), Simbolo = Enums.EnumTipos.SMENOS};
                    case '*' : return new Token() { Coluna = coluna, Linha = linha, Lexema = c.ToString(), Simbolo = Enums.EnumTipos.SMULTIPLICACAO};                    
                }
            }       

            if(c == '(')
            {
                return new Token()
                {
                    Coluna = coluna,
                    Linha = linha,
                    Lexema = c.ToString(),
                    Simbolo = Enums.EnumTipos.SABRE_PARENTESIS

                };
            }
            if(c == ')')
            {
                return new Token()
                {
                    Coluna = coluna,
                    Linha = linha,
                    Lexema = c.ToString(),
                    Simbolo = Enums.EnumTipos.SFECHA_PARENTESIS

                };
            }

            return new Token()
            {
                Coluna = coluna,
                Linha = linha,
                Lexema = c.ToString(),
                Simbolo = Enums.EnumTipos.SERRO
            };
        }
    }
}
