using System;

namespace ejercicioJugador
{
    public interface Jugador
    {
        bool Correr(int minutos);
        bool Cansado();
        void descansar(int minutos);
    }
    public class Amateur : Jugador
    {
        public int energia = 20;
        public int energiaMax = 20;
        public bool Correr(int minutos)
        {
            if (energia >= minutos)
            {
                energia -= minutos;
                return true;
            }
            else
            {
                energia = 0;
                return false;
            }
        }
        public bool Cansado()
        {
            if (energia > 0)
                return false;
            else
                return true;
        }
        public void descansar(int minutos)
        {
            energia += minutos;
            if (energia > energiaMax)
                energia = energiaMax;
        }
    }
    public class Profesional : Jugador
    {
        public int energia = 40;
        public int energiaMax = 40;
        public bool Correr(int minutos)
        {
            if (energia >= minutos)
            {
                energia -= minutos;
                return true;
            }
            else
            {
                energia = 0;
                return false;
            }
        }
        public bool Cansado()
        {
            if (energia > 0)
                return false;
            else
                return true;
        }
        public void descansar(int minutos)
        {
            energia += minutos;
            if (energia > energiaMax)
                energia = energiaMax;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Jugador jugador1 = new Amateur();
            Jugador jugador2 = new Profesional();

            Console.WriteLine("Jugador Amateur corre 10 minutos...");
            Console.WriteLine(jugador1.Correr(10)); // true
            Console.WriteLine("¿Está cansado?: " + jugador1.Cansado()); // false

            Console.WriteLine("Jugador Profesional corre 50 minutos...");
            Console.WriteLine(jugador2.Correr(50)); // false (energía no alcanza)
            Console.WriteLine("¿Está cansado?: " + jugador2.Cansado()); // true

            Console.WriteLine("Jugador Profesional descansa 20 minutos...");
            jugador2.descansar(20);
            Console.WriteLine("¿Ahora está cansado?: " + jugador2.Cansado()); // false
        }
    }
}
 
