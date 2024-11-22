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
    [SerializeField]
    float divRate;
    [SerializeField]
    float minSize;


    Rigidbody2D rb;

    void Start()
    {
        initialForceDirection.Normalize();

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(initialForceDirection*initialForceMagnitud, ForceMode2D.Impulse);
    }
    public void Init(Vector2 initialForceDirection, float initialForceMagnitud, float size)
    {
        this.initialForceDirection = initialForceDirection;
        this.initialForceMagnitud = initialForceMagnitud;
        this.gameObject.transform.localScale = new Vector3(size/2, size/2);
    }
    public int Split()
    {
        if (gameObject.transform.localScale.x > minSize)
        {
            GameObject pompa1 = GameObject.Instantiate(gameObject);
            GameObject pompa2 = GameObject.Instantiate(gameObject);

            pompa1.GetComponent<Blowup>().Init(new Vector3(1, 1, 0), 5, gameObject.transform.localScale.x);
            pompa2.GetComponent<Blowup>().Init(new Vector3(-1, 1, 0), 5, gameObject.transform.localScale.x);
            
            return 2;
        }
        return 0;
    }

    public void Burst()
    {
        GameManager.GMInstance.OnBubbleDamaged(this);
    }
}
