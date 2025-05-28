using System;

namespace ejercicioVehiculos
{
    interface Vehiculos
    {
        void mover(int tiempo);
        float posicion();
        void reiniciarPosicion();

    }
}