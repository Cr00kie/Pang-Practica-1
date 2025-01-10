using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    /// <summary>
    /// HE TENIDO QUE CREAR ESTA CLASE PORQUE NO PODIA HACERLO DESDE EL MENU MANAGER
    /// EL MENU MANAGER TAMBIEN ESTA EN LA ESCENA DE LA PARTIDA Y SI LE PONGO ESTE COMPORTAMIENTO ME DARA PROBLEMAS
    /// NECESITO UN SCRIPT DISTINTO PARA ESTE COMPORTAMIENTO ESPECIFICO DE LA UI
    /// </summary>

    [SerializeField]
    Text recordText;

    private void Start()
    {
        UpdateRecordText(); //Podría poner el código de este método aquí pero me parecía mejor mantenerlo fuera del OnSceneLoaded por estructura
    }

    void UpdateRecordText()
    {
        Debug.Log("Cambiando el texto del record...");
        if (GameManager.GMInstance != null)
        { //Si no hay tiempo record el string se quedará vacío
            recordText.text = "Record: " + GameManager.GMInstance.Timer.GetTimeAsMMSS(GameManager.GMInstance.Timer.BestTime); //Uso el método de Timer para formatear el string
        }
        else recordText.text = "Record: -- : --"; //Si no hay un GM lo pensamos como que no hay un tiempo registrado
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
