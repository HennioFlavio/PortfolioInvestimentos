using PortfolioInvestimentos.Interfaces;

namespace PortfolioInvestimentos.Portfolio;


// SRP: o Portfolio é responsável por armazenar ativos
// e realizar cálculos sobre o conjunto de ativos.
// O T é um tipo genérico.
public class Portfolio<T> where T : IAtivoFinanceiro
{

    private readonly List<T> _ativos = new();

    public IReadOnlyCollection<T> Ativos => _ativos.AsReadOnly();

    public void Adicionar(T ativo)
    {
        _ativos.Add(ativo);
    }

    public decimal ValorTotal => _ativos.Sum(a => a.ValorAtual);

    // LSP + DIP: o Portfolio trabalha com a abstração
    // IAtivoFinanceiro, podendo receber qualquer implementação válida.
    public decimal CalcularRentabilidadeMediaPonderada()
    {
        var valorTotal = _ativos.Sum(a => a.ValorAtual);

        if (valorTotal == 0)
            return 0;

        return _ativos.Sum(
            a => a.CalcularRentabilidade() * a.ValorAtual
        ) / valorTotal;
    }

}