using System;
using System.Collections.Generic;
using System.Text;

namespace Envolti.Excecoes.CalculoExceptions
{
    public class EnvoltiException : Exception
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }

        public EnvoltiException(int codigo, string mensagem) : base(mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }
    }
}
