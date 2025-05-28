using System;

namespace ejercicioVehiculos
{
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
}