using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI title;

    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void Inform(string message)
    {
        gameObject.SetActive(true);
        title.text = message;
    }
}
