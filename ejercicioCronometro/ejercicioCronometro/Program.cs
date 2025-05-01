using System;

namespace ejercicioCronometro
{
    class Program
    {
        static void Main(string[] args)
        {
            Cronometro cronometro = new Cronometro();
            for(int i=0; i<5000; i++)
            {
                cronometro.IncrementarTiempo();
            }
            Console.WriteLine(cronometro.MostrarTiempo());
        }
    }
}
