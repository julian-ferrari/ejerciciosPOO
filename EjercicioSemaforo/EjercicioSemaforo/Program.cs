using System;

class Semaforo
{
    private enum Estado { Rojo, RojoAmarillo, Verde, Amarillo, Intermitente }
    private Estado estadoActual;
    private int tiempoRestante;
    private bool intermitente;

    public Semaforo(string colorInicial)
    {
        estadoActual = colorInicial.ToLower() switch
        {
            "rojo" => Estado.Rojo,
            "rojo-amarillo" => Estado.RojoAmarillo,
            "verde" => Estado.Verde,
            "amarillo" => Estado.Amarillo,
            _ => throw new ArgumentException("Color inicial no válido")
        };
        tiempoRestante = ObtenerDuracion(estadoActual);
        intermitente = false;
    }

    public void PasoDelTiempo(int segundos)
    {
        while (segundos > 0)
        {
            if (intermitente)
            {
                tiempoRestante = 1;
            }
            else if (tiempoRestante <= 0)
            {
                CambiarEstado();
                tiempoRestante = ObtenerDuracion(estadoActual);
            }
            tiempoRestante--;
            segundos--;
        }
    }

    private void CambiarEstado()
    {
        estadoActual = estadoActual switch
        {
            Estado.Rojo => Estado.RojoAmarillo,
            Estado.RojoAmarillo => Estado.Verde,
            Estado.Verde => Estado.Amarillo,
            Estado.Amarillo => Estado.Rojo,
            _ => estadoActual
        };
    }

    private int ObtenerDuracion(Estado estado)
    {
        return estado switch
        {
            Estado.Rojo => 30,
            Estado.RojoAmarillo => 2,
            Estado.Verde => 20,
            Estado.Amarillo => 2,
            _ => 1
        };
    }

    public void PonerEnIntermitente()
    {
        intermitente = true;
        estadoActual = Estado.Intermitente;
    }

    public void SacarDeIntermitente(string color)
    {
        intermitente = false;
        estadoActual = color.ToLower() switch
        {
            "rojo" => Estado.Rojo,
            "rojo-amarillo" => Estado.RojoAmarillo,
            "verde" => Estado.Verde,
            "amarillo" => Estado.Amarillo,
            _ => throw new ArgumentException("Color no válido")
        };
        tiempoRestante = ObtenerDuracion(estadoActual);
    }

    public void MostrarColor()
    {
        if (intermitente)
            Console.WriteLine("Amarillo intermitente");
        else
            Console.WriteLine(estadoActual);
    }
}

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

