using System;

namespace ejercicioCronometro
{
    class Cronometro
    {
        public int segundos;
        public int minutos;

        public Cronometro()
        {
            segundos = 0;
            minutos = 0;
        }
        public void Reiniciar()
        {
            segundos = 0;
            minutos = 0;
        }
        public void IncrementarTiempo()
        {
            segundos++;
            if (segundos >= 60)
            {
                minutos++;
                segundos -= 60;
            }
        }
        public string MostrarTiempo()
        {
            return $"El tiempo es {minutos} minutos {segundos} segundos."; 
        }
    }
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
