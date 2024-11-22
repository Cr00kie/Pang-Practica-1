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
        UpdateRecordText(); //Podr�a poner el c�digo de este m�todo aqu� pero me parec�a mejor mantenerlo fuera del OnSceneLoaded por estructura
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) //Cuando se cargue la escena, si la escena es la misma que donde est� este componente que actualice el texto (De est� manera cada vez que se vuelva al men� se actualiza el texto del record)
    {
       if(scene == this.gameObject.scene)
        {
            
        }
    }

    void UpdateRecordText()
    {
        Debug.Log("Cambiando el texto del record...");
        if (GameManager.GMInstance != null)
        { //Si no hay tiempo record el string se quedar� vac�o
            recordText.text = "Record: " + GameManager.GMInstance.timer.GetTimeAsMMSS(GameManager.GMInstance.BestTime); //Uso el m�todo de Timer para formatear el string
        }
        else recordText.text = "Record: -- : --"; //Si no hay un GM lo pensamos como que no hay un tiempo registrado
    }
}
