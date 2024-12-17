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
            DontDestroyOnLoad(gameObject);
        }
        
    }
    #endregion

    [SerializeField]
    UIManager uiManager;
    public void SetUIManager(UIManager newUIManager) { uiManager = newUIManager; }

    [SerializeField]
    public Timer timer;

    private int bubbleCount;

    public void StartGame() //Este método se debe llamar al entrar en la escena para que así se reestablezcan los valores adecuados
    {
        timer.ResetTimer(); //Al entrar en la escena se reinicia el reloj a 0
        timer.StartTimer(); //Comienza a contar el reloj
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
            timer.UpdateBestTime(); // Se actualiza le timepo record
        }
        Debug.Log($"{bubbleCount} bubbles");
    }

    
}
