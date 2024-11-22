using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Patrón singleton
    #region
    public static GameManager GMInstance { get; private set; } 

    // Start is called before the first frame update
    void Awake()
    {
        if(GMInstance != null && GMInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            GMInstance = this;
        }
    }
    #endregion

    void Start() //Cuando se crea el GameManager, subscribo el método "OnSceneLoaded" a el evento "sceneLoaded" para que llame al método cuando se cargue una escena
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        StartGame(); // Si se ha creado el GameManager es porque estamos en la escena de la partida entonces tiene que asignar las variables
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) //Este método se llama cuando se carga una escena cualquiera y te da la escena cargada y el modo
    {
        if (scene.buildIndex != 1) // si la escena cargada en el buildIndex es 1 es la escena del Menu Principal entonces no queremos que inicialice las variables
        {
            StartGame();
        }
    }


    [SerializeField]
    UIManager uiManager;

    [SerializeField]
    public Timer timer;

    // PONGO "double?" para hacer que la propiedad pueda ser "null". Quiero usar el valor null como que no hay ningún tiempo registrado.
    public double? BestTime { get; private set; } = null; // Esto es un getter y un setter de la propiedad BestTime, permite acceder a la variable publicamente pero no modificarla 
    void UpdateBestTime(double newTime)
    {
        if(BestTime == null || newTime < BestTime) //Si el nuevo tiempo es mejor ó no hay un tiempo registrado que el anterior record se convierte en el record
        {
            BestTime = newTime;
        }
    }

    private int bubbleCount;

    public void StartGame() //Este método se debe llamar al entrar en la escena para que así se reestablezcan los valores adecuados
    {
        timer.ResetTimer(); //Al entrar en la escena se reinicia el reloj a 0
        timer.StartTimer(); //Comienza a contar el reloj
        uiManager = FindObjectsOfType<UIManager>()[0].GetComponent<UIManager>(); // Devuelve un array de objetos del tipo UIManager, y cómo solo debería haber uno cojo el primero que tenga el array
        bubbleCount = FindObjectsByType(typeof(Blowup), FindObjectsSortMode.None).Length; // Devuelve un array de objetos del tipo Blowup (serían las pompas), y guardo el tamaño del array en la variable
        Debug.Log($"{bubbleCount} bubbles");
    }

    public void OnPlayerDamaged(GameObject playerDamaged)
    {
        timer.StopTimer();
        uiManager.Inform("Has Perdido!");
        Destroy(playerDamaged);
    }
    public void OnBubbleDamaged(Blowup damagedBubble)
    {
        bubbleCount += damagedBubble.Split() - 1;
        Destroy(damagedBubble.gameObject);
        if ( bubbleCount == 0)
        {
            timer.StopTimer(); // Se para el contador
            uiManager.Inform("Has Ganado!"); // Se cambia la interfaz para que muestre el texto y el boton de continuar
            UpdateBestTime(timer.GetTime()); // Se actualiza le timepo record
        }
        Debug.Log($"{bubbleCount} bubbles");
    }

    
}
