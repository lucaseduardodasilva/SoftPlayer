namespace Envolti.Interfaces
{
    public interface ICalculosServico
    {
        string CalculaValorTotalComJurosCompostos(decimal valorInicial, int meses);
    }
}
