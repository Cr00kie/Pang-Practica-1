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

    public double GetTime() //"Getter" que permite acceder al valor de seconds (se podría hacer una property con { get; private set;})
    {
        return seconds;
    }


    void Update()
    {
        if (isCounting) //Si counting es false entonces deja de contar
        {
            seconds += Time.deltaTime;
        }
    }
}
