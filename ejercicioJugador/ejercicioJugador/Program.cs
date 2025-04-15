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
            Console.WriteLine("Hello World!");
        }
    }
}
 
