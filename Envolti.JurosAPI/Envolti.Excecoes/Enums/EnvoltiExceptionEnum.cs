namespace Envolti.Excecoes.Enums
{
    public class EnvoltiExceptionEnum : BaseEnum<EnvoltiExceptionEnum, string>
    {
        public static readonly EnvoltiExceptionEnum VALORES_INVALIDOS = new EnvoltiExceptionEnum(1, "Você deve informar valores.");


        protected EnvoltiExceptionEnum(int codigo, string mensagem) : base(codigo, mensagem) { }
    }
}
