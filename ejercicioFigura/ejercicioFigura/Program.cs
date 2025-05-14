using System;

namespace ejercicioFigura
{
    class Program
    {
        static void Main(string[] args)
        {
            Figura[] figuras = new Figura[4];

            figuras[0] = new Rectangulo(4, 5);
            figuras[1] = new Triangulo(3, 4);
            figuras[2] = new Cuadrado(6);
            figuras[3] = new Circulo(3);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Figura: {i + 1}");
                Console.WriteLine($"Área: {figuras[i].CalcularArea()}");
                Console.WriteLine($"Perímetro: {figuras[i].CalcularPerimetro()}");
            }
            /*
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
            */
        }
    }
}
