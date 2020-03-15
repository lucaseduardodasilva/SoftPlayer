namespace Envolti.Servicos._Util
{
    public static class Util
    {
        public static decimal CalculaPotencia(decimal numero, int potencia)
        {
            decimal resultado = 1;

            if (potencia > 0)
            {
                for (int i = 1; i <= potencia; ++i)
                {
                    resultado *= numero;
                }
            }
            else if (potencia < 0)
            {
                for (int i = -1; i >= potencia; --i)
                {
                    resultado /= numero;
                }
            }

            return resultado;
        }
    }
}
