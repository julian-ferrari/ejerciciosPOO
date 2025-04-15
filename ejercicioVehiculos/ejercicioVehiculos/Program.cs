using System;

namespace ejercicioVehiculos
{
    interface Vehiculos
    {
        void mover(int tiempo);
        float posicion();
        void reiniciarPosicion();

    }
    public class Auto : Vehiculos
    {
        public float velocidad;
        public float posicionActual;

        public Auto(float v = 40)
        {
            velocidad = v;
            posicionActual = 0;
        }
        public void mover(int tiempo)
        {
            posicionActual += velocidad * tiempo;
        }

        public float posicion()
        {
            return posicionActual;
        }

        public void reiniciarPosicion()
        {
            posicionActual = 0;
        }
    }
    public class Camion : Vehiculos
    {
        public float velocidad = 30;
        public float posicionActual = 0;

        public void mover(int tiempo)
        {
            posicionActual += velocidad * tiempo;
        }

        public float posicion()
        {
            return posicionActual;
        }

        public void reiniciarPosicion()
        {
            posicionActual = 0;
        }
    }
    public class Bicicleta : Vehiculos
    {
        public float velocidad = 10;
        public float posicionActual = 0;

        public void mover(int tiempo)
        {
            posicionActual += velocidad * tiempo;
        }

        public float posicion()
        {
            return posicionActual;
        }

        public void reiniciarPosicion()
        {
            posicionActual = 0;
        }
    }
    public class Carrera
    {
        public Vehiculos v1;
        public Vehiculos v2;

        public Carrera(Vehiculos vehiculo1, Vehiculos vehiculo2)
        {
            v1 = vehiculo1;
            v2 = vehiculo2;
        }

    }
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
