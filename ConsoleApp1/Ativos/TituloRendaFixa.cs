using PortfolioInvestimentos.Interfaces;

namespace PortfolioInvestimentos.Ativos;

// SRP: a classe TituloRendaFixa concentra os dados
// e comportamentos específicos de um título de renda fixa.
public class TituloRendaFixa :
    IAtivoFinanceiro,
    IAtivoComVencimento
{
    public string Nome { get; set; } = string.Empty;

    public decimal ValorInvestido { get; set; }

    public decimal TaxaAnual { get; set; }

    public DateTime DataAplicacao { get; set; }

    public DateTime DataVencimento { get; set; }

   private int DiasDecorridos =>
    (DateTime.Now - DataAplicacao).Days;

    public decimal ValorAtual =>
        ValorInvestido * (1 + CalcularRentabilidade() / 100);
    public decimal CalcularRentabilidade()
    {
        return TaxaAnual * (DiasDecorridos / 365m);
    }

    public int DiasParaVencimento()
    {
        return (DataVencimento - DateTime.Now).Days;
    }
}
