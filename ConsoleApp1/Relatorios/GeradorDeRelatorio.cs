using PortfolioInvestimentos.Interfaces;
using PortfolioInvestimentos.Portfolio;

namespace PortfolioInvestimentos.Relatorios;

// SRP: a classe é responsável por gerar o relatório dos ativos.
public class GeradorDeRelatorio
{
    // DIP: o relatório depende da abstração IAtivoFinanceiro,
    // e não de classes concretas como Acao ou Cripto.
    public void Gerar(Portfolio<IAtivoFinanceiro> portfolio)
    {
        Console.WriteLine("=== RELATÓRIO DINÂMICO ===");
        Console.WriteLine();

        foreach (var ativo in portfolio.Ativos)
        {
            var tipo = ativo.GetType();

            Console.WriteLine($"Tipo: {tipo.Name}");

            ExibirPropriedades(ativo, tipo);

            var rentabilidade = ativo.CalcularRentabilidade();

            Console.WriteLine(
                $"  Rentabilidade: {rentabilidade:N2}%"
            );

            ExibirInterfaces(ativo, tipo);

            Console.WriteLine();
        }
    }

    private void ExibirPropriedades(object ativo, Type tipo)
    {
        var propriedades = tipo.GetProperties();

        foreach (var propriedade in propriedades)
        {
            var valor = propriedade.GetValue(ativo);

            Console.WriteLine(
                $"  {propriedade.Name}: {valor:N2}"
            );
        }
    }

    private void ExibirInterfaces(object ativo, Type tipo)
    {
        var interfaces = tipo.GetInterfaces();

        foreach (var interfaceAtivo in interfaces)
        {
            if (interfaceAtivo == typeof(IGeradorDeRenda))
            {
                var gerador = (IGeradorDeRenda)ativo;

                Console.WriteLine(
                    "  Implementa: IGeradorDeRenda"
                );

                Console.WriteLine(
                    $"  Renda periódica: {gerador.CalcularRendaPeriodica():C2}"
                );
            }

            if (interfaceAtivo == typeof(IAtivoComVencimento))
            {
                var vencimento = (IAtivoComVencimento)ativo;

                Console.WriteLine(
                    "  Implementa: IAtivoComVencimento"
                );

                Console.WriteLine(
                    $"  Dias para vencimento: {vencimento.DiasParaVencimento()}"
                );
            }

            if (interfaceAtivo == typeof(IAtivoNegociavel))
            {
                var negociavel = (IAtivoNegociavel)ativo;

                Console.WriteLine(
                    "  Implementa: IAtivoNegociavel"
                );

                Console.WriteLine(
                    $"  Variação diária: {negociavel.VariacaoDiaria:N2}%"
                );
            }
        }
    }
}