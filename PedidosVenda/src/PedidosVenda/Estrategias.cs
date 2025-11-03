using System;

public static class Estrategias
{
    public static decimal FreteFixo(decimal valor) 
    {
        return valor + 15.0m;
    }
    
    public static decimal FretePercentual(decimal valor) 
    {
        return valor * 1.05m;
    }
    
    public static decimal FreteGratis(decimal valor) 
    {
        return valor;
    }

    public static decimal SemPromocao(decimal valor) 
    {
        return valor;
    }
    
    public static decimal DescontoFixo(decimal valor) 
    {
        return valor - 10.0m;
    }
    
    public static decimal DescontoPercentual(decimal valor) 
    {
        return valor * 0.85m;
    }
}
