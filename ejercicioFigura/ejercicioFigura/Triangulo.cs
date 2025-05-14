using System;

public class Triangulo : Figura
{
    public double _base;
    public double altura;

    public Triangulo(double b, double a)
    {
        _base = b;
        altura = a;
    }

    public double CalcularArea()
    {
        return (_base * altura) / 2;
    }

    public double CalcularPerimetro()
    {
        return _base * 3;
    }
}
