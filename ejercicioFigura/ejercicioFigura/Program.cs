using System;

namespace ejercicioFigura
{
    interface Figura
    {
        double CalcularArea();
        double CalcularPerimetro();
    }
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
    class Program
    {
        static void Main(string[] args)
        {
            Figura rectangulo = new Rectangulo(4, 5);
            Figura triangulo = new Triangulo(3, 4);
            Figura cuadrado = new Cuadrado(6);
            Figura circulo = new Circulo(3);

            Console.WriteLine("Rectángulo:");
            Console.WriteLine($"Área: {rectangulo.CalcularArea()}");
            Console.WriteLine($"Perímetro: {rectangulo.CalcularPerimetro()}");
            
            Console.WriteLine("\nTriángulo:");
            Console.WriteLine($"Área: {triangulo.CalcularArea()}");
            Console.WriteLine($"Perímetro: {triangulo.CalcularPerimetro()}");

            Console.WriteLine("\nCuadrado:");
            Console.WriteLine($"Área: {cuadrado.CalcularArea()}");
            Console.WriteLine($"Perímetro: {cuadrado.CalcularPerimetro()}");

            Console.WriteLine("\nCírculo:");
            Console.WriteLine($"Área: {circulo.CalcularArea()}");
            Console.WriteLine($"Perímetro: {circulo.CalcularPerimetro()}");
        }
    }
}
