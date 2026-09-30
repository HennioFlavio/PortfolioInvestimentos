namespace PortfolioInvestimentos.Interfaces;

// Interface específica: ativos negociáveis em mercado
public interface IAtivoNegociavel
{
    decimal PrecoMercado { get; }
    decimal VariacaoDiaria { get; }// percentual de variação do dia
}