using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blowup : MonoBehaviour
{
    [SerializeField]
    Vector2 initialForceDirection;
    [SerializeField]
    float initialForceMagnitud;
    

    Rigidbody2D rb;

    void Start()
    {
        initialForceDirection.Normalize();

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(initialForceDirection*initialForceMagnitud, ForceMode2D.Impulse);
    }

    public void Burst()
    {
        Destroy(gameObject);
        GameManager.GMInstance.OnBubbleDamaged();
    }
}
