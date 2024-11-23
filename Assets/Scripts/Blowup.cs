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
        if (gameObject.transform.localScale.x > minSize) //Si el tamaño de la pompa es más grande que el minSize entonces permitimos que se vuelvan a dividir
        {
            GameObject pompa1 = GameObject.Instantiate(gameObject);
            GameObject pompa2 = GameObject.Instantiate(gameObject);

            //No hace falta comprobar que no se null porque sabemos que siempre lo deben de tener
            pompa1.GetComponent<Blowup>().Init(new Vector3(1, 1, 0), 5, gameObject.transform.localScale.x);
            pompa2.GetComponent<Blowup>().Init(new Vector3(-1, 1, 0), 5, gameObject.transform.localScale.x);
            
            return 2; //Devolvemos 2 porque hemos creado dos pompas
        }
        return 0; //Si era la pompa mas pequeña devolvemos 0 porque no se han creado pompas
    }

    public void Burst()
    {
        GameManager.GMInstance.OnBubbleDamaged(this);
    }
}
