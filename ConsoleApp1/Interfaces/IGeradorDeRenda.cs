namespace PortfolioInvestimentos.Interfaces;

// Interface específica: ativos que geram renda periódica
// como dividendos, distribuições etc.
public interface IGeradorDeRenda
{
    decimal CalcularRendaPeriodica();
    string Periodicidade { get; } // Ex.: "Mensal", "Trimestral", "Anual"
}