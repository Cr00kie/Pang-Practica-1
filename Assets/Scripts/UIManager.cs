using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text title;

    [SerializeField]
    Text timer;

    [SerializeField]
    GameObject gameoverUI;

    public void Start()
    { //Por si está desactivado lo activo para que se vea sí o sí
        gameoverUI.SetActive(false);
    }
    public void Update()
    {
        
        double time = GameManager.GMInstance.GetTime()*1000; //Obtenemos el tiempo del contador y lo pasamos a milisegundos (para tener la mayor precisión por si queremos que cuente los milisegundos)
        int min = (int)(time / 60000); //Cálculo de los minutos
        int sec = (int)(time % 60000 / 1000); //Calculo de los segundos
        //int milSec = (int)((time%60000)%1000); //Calculo de los milisegundos

        timer.text = min.ToString("D2") + " : " + sec.ToString("D2"); //CONTADOR QUE MUESTRA (MM) : (SS)
        //timer.text = min.ToString("D2") + " : " + sec.ToString("D2") + " : " + milSec.ToString("D3"); //VERSION QUE MUESTRA LOS MILISEGUNDOS
    }
    public void Inform(string message)
    {
        gameoverUI.SetActive(true);
        title.text = message;
        Debug.Log(message);
    }
}
