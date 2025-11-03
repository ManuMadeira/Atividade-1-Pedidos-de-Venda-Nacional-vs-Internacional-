using System;

public class Pedido
{
    private readonly Func<decimal, decimal> _frete;
    private readonly Func<decimal, decimal> _promocao;

    public Pedido(Func<decimal, decimal> frete, Func<decimal, decimal> promocao)
    {
        _frete = frete;
        _promocao = promocao;
    }

    public string Processar()
    {
        Validar();
        decimal total = CalcularTotal();
        return EmitirRecibo(total);
    }

    protected virtual void Validar() 
    {
    }

    protected virtual decimal CalcularSubtotal() 
    {
        return 100m;
    }

    protected virtual string EmitirRecibo(decimal total) 
    {
        return "Recibo Base: " + total.ToString("C");
    }

    private decimal CalcularTotal()
    {
        decimal subtotal = CalcularSubtotal();
        decimal comFrete = _frete(subtotal);
        decimal comPromocao = _promocao(comFrete);
        return comPromocao;
    }
}
