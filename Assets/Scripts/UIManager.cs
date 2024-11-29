using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        GameManager.GMInstance.SetUIManager(this);
        GameManager.GMInstance.StartGame();
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
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
