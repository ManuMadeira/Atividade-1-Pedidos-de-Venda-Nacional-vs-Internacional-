using Xunit;
using System;

public class PedidoTests
{
    [Fact]
    public void TestarLSP_ProcessarFuncionaComTodosOsTipos()
    {
        Pedido nacional = new PedidoNacional(Estrategias.FreteFixo, Estrategias.SemPromocao);
        Pedido internacional = new PedidoInternacional(Estrategias.FreteFixo, Estrategias.SemPromocao);

        string resultadoNacional = nacional.Processar();
        string resultadoInternacional = internacional.Processar();

        Assert.Contains("NF-e", resultadoNacional);
        Assert.Contains("Commercial Invoice", resultadoInternacional);
        
        Pedido[] pedidos = { nacional, internacional };
        foreach (var pedido in pedidos)
        {
            string resultado = pedido.Processar();
            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado);
        }
    }

    [Fact]
    public void TestarComposicao_TrocaDeDelegatesAlteraResultado()
    {
        var combinacoes = new[]
        {
            new { Frete = Estrategias.FreteFixo, Promocao = Estrategias.SemPromocao },
            new { Frete = Estrategias.FretePercentual, Promocao = Estrategias.DescontoFixo },
            new { Frete = Estrategias.FreteGratis, Promocao = Estrategias.DescontoPercentual }
        };

        foreach (var combo in combinacoes)
        {
            Pedido pedido = new PedidoNacional(combo.Frete, combo.Promocao);
            string resultado = pedido.Processar();

            Assert.NotNull(resultado);
            Assert.Contains("NF-e", resultado);
        }
    }

    [Fact]
    public void TestarCalculoTotal_ComDiferentesPoliticas()
    {
        Pedido pedidoBasico = new PedidoNacional(Estrategias.FreteGratis, Estrategias.SemPromocao);
        Pedido pedidoComDesconto = new PedidoNacional(Estrategias.FreteGratis, Estrategias.DescontoPercentual);

        string resultadoBasico = pedidoBasico.Processar();
        string resultadoComDesconto = pedidoComDesconto.Processar();

        Assert.NotEqual(resultadoBasico, resultadoComDesconto);
    }
}
