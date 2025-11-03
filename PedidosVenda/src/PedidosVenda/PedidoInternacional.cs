using System;

public sealed class PedidoInternacional : Pedido
{
    public PedidoInternacional(Func<decimal, decimal> frete, Func<decimal, decimal> promocao) 
        : base(frete, promocao) { }

    protected override void Validar()
    {
        base.Validar();
    }

    protected override decimal CalcularSubtotal() 
    {
        return base.CalcularSubtotal() * 1.2m;
    }

    protected override string EmitirRecibo(decimal total) 
    {
        return "Commercial Invoice: " + total.ToString("C");
    }
}
