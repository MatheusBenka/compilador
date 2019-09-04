using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Compilador
{
    public static class Enums
    {
        public enum EnumTipos
        {
            [Description("usado para tokens nao reconhecidos")]
            SERRO,
            [Description("program")]
            SPROGRAMA,
            [Description("var")]
            SVAR,
            [Description(":")]
            SDOISPONTOS,
            [Description("inicio")]
            SINICIO,
            [Description("fim")]
            SFIM,
            [Description(":=")]
            SATRIBUICAO,
            [Description(":")]
            STIPO,
            [Description("escreva")]            
            SESCREVA,
            [Description("inteiro")]            
            SINTEIRO,
            [Description(";")]            
            SPONTO_E_VIRGULA,
            [Description(".")]
            SPONTO,
            [Description("+")]
            SMAIS,
            [Description("-")]
            SMENOS,
            [Description("*")]
            SMULTIPLICACAO,
            [Description("5")]
            SNUMERO,
            [Description("x,teste")]
            SIDENTIFICADOR,
            [Description("(")]
            SABRE_PARENTESIS,
            [Description(")")]
            SFECHA_PARENTESIS,            
        }
    }
}
