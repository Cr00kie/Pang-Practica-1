using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {  
        if(FindObjectsByType<DontDestroyScript>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
