using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public void Harm()
    {
        GameManager.GMInstance.OnPlayerDamaged(gameObject);
    }
}
