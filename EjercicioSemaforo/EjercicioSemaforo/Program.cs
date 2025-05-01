using System;
class Program
{
    static void Main()
    {
        Semaforo semaforo = new Semaforo("Rojo");
        semaforo.MostrarColor();
        semaforo.PasoDelTiempo(30);
        semaforo.MostrarColor();
        semaforo.PonerEnIntermitente();
        semaforo.MostrarColor();
        semaforo.SacarDeIntermitente("Verde");
        semaforo.MostrarColor();
    }
}

