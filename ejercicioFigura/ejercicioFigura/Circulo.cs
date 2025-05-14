using System;

public class Circulo : Figura
{
    public double radio;
    public static readonly double Pi = 3.1416;

    public Circulo(double r)
    {
        radio = r;
    }

    public double CalcularArea()
    {
        return Pi * (radio * radio);
    }

    public double CalcularPerimetro()
    {
        return 2 * Pi * radio;
    }
}
