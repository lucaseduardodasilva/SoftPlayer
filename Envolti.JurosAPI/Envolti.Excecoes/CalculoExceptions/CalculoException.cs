using System;
using System.Collections.Generic;
using System.Text;

namespace Envolti.Excecoes.CalculoExceptions
{
    public class CalculoException : Exception
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }

        public CalculoException(int codigo, string mensagem) : base(mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }
    }
}
