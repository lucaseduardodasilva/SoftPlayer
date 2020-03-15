using Envolti.Dominio.Testes.Entidades;

namespace Envolti.Dominio.Testes._Builders
{
    public class JurosBuilder
    {
        private decimal _valorInicial = (decimal)100;
        private int _meses = 5;
        private decimal _taxaJuros = (decimal)0.01;

        public static JurosBuilder Novo()
        {
            return new JurosBuilder();
        }

        public Juros Build()
        {
            return new Juros(_valorInicial, _meses, _taxaJuros);
        }

        public JurosBuilder ComValorInicial(decimal valorInicial)
        {
            _valorInicial = valorInicial;
            return this;
        }

        public JurosBuilder ComMeses(int meses)
        {
            _meses = meses;
            return this;
        }

        public JurosBuilder ComTaxaJuros(decimal taxaJuros)
        {
            _taxaJuros = taxaJuros;
            return this;
        }
    }
}
