using System;

namespace ejercicioJugador
{
    class Program
    {
        static void Main(string[] args)
        {
            Jugador jugador1 = new Amateur();
            Jugador jugador2 = new Profesional();

            Console.WriteLine("Jugador Amateur corre 10 minutos...");
            Console.WriteLine(jugador1.Correr(10));
            Console.WriteLine("¿Está cansado?: " + jugador1.Cansado());

            Console.WriteLine("Jugador Profesional corre 50 minutos...");
            Console.WriteLine(jugador2.Correr(50));
            Console.WriteLine("¿Está cansado?: " + jugador2.Cansado());

            Console.WriteLine("Jugador Profesional descansa 20 minutos...");
            jugador2.descansar(20);
            Console.WriteLine("¿Ahora está cansado?: " + jugador2.Cansado());
        }
    }
}
 
