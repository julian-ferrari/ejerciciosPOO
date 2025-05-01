using System;
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
