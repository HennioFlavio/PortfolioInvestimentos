using PortfolioInvestimentos.Interfaces;

namespace PortfolioInvestimentos.Ativos;

// OCP: podemos adicionar um novo tipo de ativo
// sem modificar o Portfolio nem o gerador de relatório.
// ISP: Cripto implementa apenas as interfaces que fazem sentido.
public class Cripto :
    IAtivoFinanceiro,
    IAtivoNegociavel
{
    public string Nome { get; set; } = string.Empty;

    public decimal Quantidade { get; set; }

    public decimal PrecoMedioCompra { get; set; }

    public decimal PrecoMercado { get; set; }

    public decimal VariacaoDiaria { get; set; }

    public decimal ValorInvestido =>
        Quantidade * PrecoMedioCompra;

    public decimal ValorAtual =>
        Quantidade * PrecoMercado;

    public decimal CalcularRentabilidade()
    {
        return ((ValorAtual - ValorInvestido)
                / ValorInvestido) * 100;
    }
}