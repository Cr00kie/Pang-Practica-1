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
        this.gameObject.transform.localScale = new Vector3(size, size);
    }
    public int Split()
    {
        if (gameObject.transform.localScale.x > minSize) //Si el tamaño de la pompa es más grande que el minSize entonces permitimos que se vuelvan a dividir
        {
            Blowup pompa1 = GameObject.Instantiate<Blowup>(this);
            Blowup pompa2 = GameObject.Instantiate<Blowup>(this);

            pompa1.Init(new Vector3(1, 1, 0), 5, gameObject.transform.localScale.x/2);
            pompa2.Init(new Vector3(-1, 1, 0), 5, gameObject.transform.localScale.x/2);
            
            return 2; //Devolvemos 2 porque hemos creado dos pompas
        }
        return 0; //Si era la pompa mas pequeña devolvemos 0 porque no se han creado pompas
    }

    public void Burst()
    {
        GameManager.GMInstance.OnBubbleDamaged(this);
    }
}
