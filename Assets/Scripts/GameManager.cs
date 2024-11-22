using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Patr�n singleton
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

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        StartGame();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != 1)
        {
            StartGame();
        }
    }


    [SerializeField]
    UIManager uiManager;

    [SerializeField]
    Timer timer;

    private int bubbleCount;

    public void StartGame() //Este m�todo se debe llamar al entrar en la escena para que as� se reestablezcan los valores adecuados
    {
        timer.ResetTimer(); //Al entrar en la escena se reinicia el reloj a 0
        timer.StartTimer(); //Comienza a contar el reloj
        uiManager = FindObjectsOfType<UIManager>()[0].GetComponent<UIManager>(); // Devuelve un array de objetos del tipo UIManager, y c�mo solo deber�a haber uno cojo el primero que tenga el array
        bubbleCount = FindObjectsByType(typeof(Blowup), FindObjectsSortMode.None).Length; // Devuelve un array de objetos del tipo Blowup (ser�an las pompas), y guardo el tama�o del array en la variable
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
            timer.StopTimer();
            uiManager.Inform("Has Ganado!");
        }
        Debug.Log($"{bubbleCount} bubbles");
    }
    public double GetTime()
    {
        return timer.GetTime();
    }

    
}
