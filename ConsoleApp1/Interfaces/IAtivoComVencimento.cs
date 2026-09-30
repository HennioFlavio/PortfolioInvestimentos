namespace PortfolioInvestimentos.Interfaces;

// Interface específica: ativos que possuem data de vencimento
public interface IAtivoComVencimento
{
    DateTime DataVencimento { get; }

    int DiasParaVencimento();
}