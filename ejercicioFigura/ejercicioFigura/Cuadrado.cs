using System;

public class Cuadrado : Figura
{
    public double lado;

    public Cuadrado(double l)
    {
        lado = l;
    }

    public double CalcularArea()
    {
        return lado * lado;
    }

    public double CalcularPerimetro()
    {
        return lado * 4;
    }
}