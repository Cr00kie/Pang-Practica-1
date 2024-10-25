using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        bubbleCount = 0;
    }
    #endregion

    [SerializeField]
    UIManager uiManager;

    private int bubbleCount;

    public void OnPlayerDamaged(GameObject playerDamaged)
    {
        uiManager.GetComponent<UIManager>().Inform("Has Perdido!");
        Destroy(playerDamaged);
    }

    public void OnBubbleCreated()
    {
        bubbleCount++;
    }
    public void OnBubbleDamaged()
    {
        bubbleCount--;
        if( bubbleCount == 0)
        {
            uiManager.GetComponent<UIManager>().Inform("Has Ganado!");
        }
    }
}
