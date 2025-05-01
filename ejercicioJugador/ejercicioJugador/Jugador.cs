using System;
public interface Jugador
{
    bool Correr(int minutos);
    bool Cansado();
    void descansar(int minutos);
}