using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harmful : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health scrHealth = collision.gameObject.GetComponent<Health>();

        if(scrHealth != null)
        {
            scrHealth.Harm();
            Destroy(gameObject);
        }
    }
}
