namespace Envolti.Excecoes.Enums
{
    public class EnvoltiExceptionEnum : BaseEnum<EnvoltiExceptionEnum, string>
    {
        public static readonly EnvoltiExceptionEnum VALORES_INVALIDOS = new EnvoltiExceptionEnum(1, "Você deve informar valores.");
        public static readonly EnvoltiExceptionEnum ERRO_CONSULTAR_JUROS = new EnvoltiExceptionEnum(2, "Erro consultar taxa de juros, verifique o Ip docker na clase Urls");


        protected EnvoltiExceptionEnum(int codigo, string mensagem) : base(codigo, mensagem) { }
    }
}
