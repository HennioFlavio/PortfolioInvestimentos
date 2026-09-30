using PortfolioInvestimentos.Interfaces;

namespace PortfolioInvestimentos.Ativos;

// SRP: a classe Acao concentra os dados e comportamentos
// específicos de uma ação.
// Classe
public class Acao :
    IAtivoFinanceiro,
    IGeradorDeRenda,
    IAtivoNegociavel
{  // Propriedade:guardam informações
    public string Nome { get; set; } = string.Empty;
    // Propriedade:guardam informações
    public decimal Quantidade { get; set; }
    // Propriedade:guardam informações
    public decimal PrecoMedioCompra { get; set; }
    // Propriedade:guardam informações
    public decimal PrecoMercado { get; set; }
    // Propriedade:guardam informações
    public decimal DividendosRecebidos { get; set; }
    // Propriedade:guardam informações
    public decimal DividendoPorAcao { get; set; }
    // Propriedade:guardam informações
    public string Periodicidade { get; set; } = string.Empty;
    // Propriedade:guardam informações
    public decimal VariacaoDiaria { get; set; }

    public decimal ValorInvestido =>
        Quantidade * PrecoMedioCompra;

    public decimal ValorAtual =>
        Quantidade * PrecoMercado;

    public decimal CalcularRentabilidade()
    {
        return ((ValorAtual + DividendosRecebidos - ValorInvestido)
                / ValorInvestido) * 100;
    }

    public decimal CalcularRendaPeriodica()
    {
        return Quantidade * DividendoPorAcao;
    }
}