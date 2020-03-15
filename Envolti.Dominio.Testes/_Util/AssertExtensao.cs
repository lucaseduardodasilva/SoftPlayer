using System;
using Xunit;

namespace Envolti.Dominio.Testes._Util
{
    public static class AssertExtensao
    {
        public static void ComMensagem(this ArgumentException exception, string mensagem)
        {
            if (exception.Message == mensagem)
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true, $"Esperava a mensagem '{mensagem}'");
            }
        }
    }
}
