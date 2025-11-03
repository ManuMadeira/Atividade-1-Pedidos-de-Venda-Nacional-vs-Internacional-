using System;

public sealed class PedidoNacional : Pedido
{
    public PedidoNacional(Func<decimal, decimal> frete, Func<decimal, decimal> promocao) 
        : base(frete, promocao) { }

    protected override void Validar()
    {
        base.Validar();
    }

    protected override decimal CalcularSubtotal() 
    {
        return base.CalcularSubtotal() * 1.1m;
    }

    protected override string EmitirRecibo(decimal total) 
    {
        return "NF-e: " + total.ToString("C");
    }
}
