using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public double Seconds { get; private set; } = 0;
    bool isCounting = false;
    public double BestTime { get; private set; } = 0; // Esto es un getter y un setter de la propiedad BestTime, permite acceder a la variable publicamente pero no modificarla 
    public void UpdateBestTime()
    {
        if (BestTime == 0 || Seconds < BestTime) //Si el nuevo tiempo es mejor ó no hay un tiempo registrado que el anterior record se convierte en el record
        {
            BestTime = Seconds;
        }
    }

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
        Seconds = 0;
    }

    public string GetTimeAsMMSS()
    {
        int min = (int)(Seconds / 60); //Cálculo de los minutos
        int sec = (int)(Seconds % 60); //Calculo de los segundos

        return min.ToString("D2") + " : " + sec.ToString("D2"); //CONTADOR QUE MUESTRA (MM) : (SS)    ".ToString("Dn")" formatea el número poniendo poniendo los 0 restantes hasta llegar al número de digitos deseados
    }
    public string GetTimeAsMMSS(double? s) //Otro método para que me devuelva el mismo formato si yo le paso segundos como parámetro
    {
        //Todo esto se podría hacer en una línea con un operador ternario pero lo dejo así para que sea más fácil de ver
        string ret;
        if (s != 0) //Comprobamos que s no es nulo
        {
            int min = (int)(s / 60); //Cálculo de los minutos
            int sec = (int)(s % 60); //Calculo de los segundos
            ret = min.ToString("D2") + " : " + sec.ToString("D2"); //CONTADOR QUE MUESTRA (MM) : (SS)    ".ToString("Dn")" formatea el número poniendo poniendo los 0 restantes hasta llegar al número de digitos deseados
        }
        else ret = "-- : --"; //Si s es nulo devolvemos este formato
        return ret;
    }


    void Update()
    {
        if (isCounting) //Si counting es false entonces deja de contar
        {
            Seconds += Time.deltaTime;
        }
    }
}
