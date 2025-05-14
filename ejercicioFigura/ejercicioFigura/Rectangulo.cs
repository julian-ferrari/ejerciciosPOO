using System;

public class Rectangulo : Figura
{
    public double _base;
    public double altura;

    public Rectangulo(double b, double a)
    {
        _base = b;
        altura = a;
    }

    public double CalcularArea()
    {
        return _base * altura;
    }

    public double CalcularPerimetro()
    {
        return 2 * (_base + altura);
    }
}
