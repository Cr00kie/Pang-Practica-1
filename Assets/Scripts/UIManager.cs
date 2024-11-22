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
        timer.text = GameManager.GMInstance.timer.GetTimeAsMMSS();
    }
    public void Inform(string message)
    {
        gameoverUI.SetActive(true);
        title.text = message;
        Debug.Log(message);
    }
}
