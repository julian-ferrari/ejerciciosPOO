using System;

namespace ejercicioVehiculos
{
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
}