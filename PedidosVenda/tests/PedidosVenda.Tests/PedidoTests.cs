using Xunit;
using System;

public class PedidoTests
{
    [Fact]
    public void TestarLSP_Basico()
    {
        // Teste mais simples sem tipos anônimos
        Func<decimal, decimal> frete = Estrategias.FreteFixo;
        Func<decimal, decimal> promocao = Estrategias.SemPromocao;

        Pedido nacional = new PedidoNacional(frete, promocao);
        Pedido internacional = new PedidoInternacional(frete, promocao);

        string resultado1 = nacional.Processar();
        string resultado2 = internacional.Processar();

        // Usar Assert.Contains corretamente
        Assert.Contains("NF-e", resultado1);
        Assert.Contains("Commercial Invoice", resultado2);
    }

    [Fact]
    public void TestarComposicao_Simples()
    {
        // Teste individual de cada combinação
        Func<decimal, decimal> freteFixo = Estrategias.FreteFixo;
        Func<decimal, decimal> semPromocao = Estrategias.SemPromocao;
        
        Pedido pedido1 = new PedidoNacional(freteFixo, semPromocao);
        string resultado1 = pedido1.Processar();
        Assert.Contains("NF-e", resultado1);

        Func<decimal, decimal> fretePercentual = Estrategias.FretePercentual;
        Func<decimal, decimal> descontoFixo = Estrategias.DescontoFixo;
        
        Pedido pedido2 = new PedidoNacional(fretePercentual, descontoFixo);
        string resultado2 = pedido2.Processar();
        Assert.Contains("NF-e", resultado2);

        Func<decimal, decimal> freteGratis = Estrategias.FreteGratis;
        Func<decimal, decimal> descontoPercentual = Estrategias.DescontoPercentual;
        
        Pedido pedido3 = new PedidoNacional(freteGratis, descontoPercentual);
        string resultado3 = pedido3.Processar();
        Assert.Contains("NF-e", resultado3);
    }

    [Fact]
    public void TestarDiferencaEntreTipos()
    {
        Func<decimal, decimal> frete = Estrategias.FreteGratis;
        Func<decimal, decimal> promocao = Estrategias.SemPromocao;

        Pedido nacional = new PedidoNacional(frete, promocao);
        Pedido internacional = new PedidoInternacional(frete, promocao);

        string resultadoNacional = nacional.Processar();
        string resultadoInternacional = internacional.Processar();

        // Devem ser diferentes porque um aplica 10% e outro 20%
        Assert.NotEqual(resultadoNacional, resultadoInternacional);
    }

    [Fact]
    public void TestarCalculo_ValoresEspecificos()
    {
        // Teste com valores conhecidos
        Func<decimal, decimal> freteFixo = Estrategias.FreteFixo;
        Func<decimal, decimal> semPromocao = Estrategias.SemPromocao;

        Pedido nacional = new PedidoNacional(freteFixo, semPromocao);
        
        string resultado = nacional.Processar();
        
        // Valor esperado: 100 * 1.1 = 110 + 15 = 125
        Assert.Contains("125", resultado);
    }
}
