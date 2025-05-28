using System;

namespace ejercicioVehiculos
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto golcito_planchado_al_piso = new Auto(45);
            Bicicleta bici = new Bicicleta();
            Camion camion = new Camion();
            bici.mover(20);
            Console.WriteLine(bici.posicion());
            bici.mover(10);
            Console.WriteLine(bici.posicion());
        }
    }
}
