using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private double seconds = 0;
    bool isCounting = false;

    public void StartTimer() //El contador sigue contando
    {
        isCounting = true;
    }
    public void StopTimer() //Para el contador
    {
        isCounting = false;
    }

    public void ResetTimer() //Reinicia el contador
    {
        seconds = 0;
    }

    public double GetTime() //"Getter" que permite acceder al valor de seconds (se podr�a hacer una property con { get; private set;})
    {
        return seconds;
    }

    public string GetTimeAsMMSS()
    {
        int min = (int)(seconds / 60); //C�lculo de los minutos
        int sec = (int)(seconds % 60); //Calculo de los segundos

        return min.ToString("D2") + " : " + sec.ToString("D2"); //CONTADOR QUE MUESTRA (MM) : (SS)    ".ToString("Dn")" formatea el n�mero poniendo poniendo los 0 restantes hasta llegar al n�mero de digitos deseados
    }
    public string GetTimeAsMMSS(double? s) //Otro m�todo para que me devuelva el mismo formato si yo le paso segundos como par�metro
    {
        //Todo esto se podr�a hacer en una l�nea con un operador ternario pero lo dejo as� para que sea m�s f�cil de ver
        string ret;
        if (s != null) //Comprobamos que s no es nulo
        {
            int min = (int)(s / 60); //C�lculo de los minutos
            int sec = (int)(s % 60); //Calculo de los segundos
            ret = min.ToString("D2") + " : " + sec.ToString("D2"); //CONTADOR QUE MUESTRA (MM) : (SS)    ".ToString("Dn")" formatea el n�mero poniendo poniendo los 0 restantes hasta llegar al n�mero de digitos deseados
        }
        else ret = "-- : --"; //Si s es nulo devolvemos este formato
        return ret;
    }


    void Update()
    {
        if (isCounting) //Si counting es false entonces deja de contar
        {
            seconds += Time.deltaTime;
        }
    }
}
