using UnityEngine;

public class Timer : MonoBehaviour
{
    private double seconds = 0;
    private double bestTime = 0;
    bool isCounting = false;
   
    public void UpdateBestTime()
    {
        if (bestTime == 0 || seconds < bestTime) //Si el nuevo tiempo es mejor ó no hay un tiempo registrado que el anterior record se convierte en el record
        {
            bestTime = seconds;
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
        seconds = 0;
    }
    public string GetBestTimeAsMMSS()
    {
        return GetTimeAsMMSS(bestTime);
    }

    public string GetCurrentTimeAsMMSS()
    {
        return GetTimeAsMMSS(seconds);
    }
    private string GetTimeAsMMSS(double? s) //Otro método para que me devuelva el mismo formato si yo le paso segundos como parámetro
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
            seconds += Time.deltaTime;
        }
    }
}
