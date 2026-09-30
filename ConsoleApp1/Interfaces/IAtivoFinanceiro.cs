namespace PortfolioInvestimentos.Interfaces;

// Interface base mínima: todo ativo financeiro deve implementar
public interface IAtivoFinanceiro
{
    string Nome { get; }
    decimal ValorInvestido { get; }
    decimal ValorAtual { get; }

    decimal CalcularRentabilidade();
}
