using PortfolioInvestimentos.Ativos;
using PortfolioInvestimentos.Interfaces;
using PortfolioInvestimentos.Portfolio;
using PortfolioInvestimentos.Relatorios;


// ==========================================
// CRIANDO OS ATIVOS
// ==========================================

var acao = new Acao
{
    Nome = "PETR4",
    Quantidade = 100,
    PrecoMedioCompra = 30m,
    PrecoMercado = 32.50m,
    DividendosRecebidos = 100m,
    DividendoPorAcao = 0.50m,
    Periodicidade = "Trimestral",
    VariacaoDiaria = 1.25m
};


var titulo = new TituloRendaFixa
{
    Nome = "CDB 2026",
    ValorInvestido = 10000m,
    TaxaAnual = 10m,
    DataAplicacao = DateTime.Now.AddDays(-100),
    DataVencimento = DateTime.Now.AddDays(265)
};


var fundo = new FundoInvestimento
{
    Nome = "Fundo XP",
    QuantidadeCotas = 100,
    ValorCotaCompra = 80m,
    ValorCotaAtual = 84.20m,
    TaxaAdministracao = 1.5m,
    RendimentoPorCota = 0.50m,
    Periodicidade = "Mensal"
};


var cripto = new Cripto
{
    Nome = "Bitcoin",
    Quantidade = 0.1m,
    PrecoMedioCompra = 3000.00m,
    PrecoMercado = 3300.00m,
    VariacaoDiaria = 2.50m
};

// ==========================================
// CRIANDO UM PORTFÓLIO DE IAtivoFinanceiro
// ==========================================

var portfolio = new Portfolio<IAtivoFinanceiro>();

portfolio.Adicionar(acao);
portfolio.Adicionar(titulo);
portfolio.Adicionar(fundo);
portfolio.Adicionar(cripto);

// ==========================================
// GERANDO O RELATÓRIO
// ==========================================

var gerador = new GeradorDeRelatorio();

gerador.Gerar(portfolio);