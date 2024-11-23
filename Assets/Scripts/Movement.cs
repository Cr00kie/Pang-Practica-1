using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    int movementSpeed;
    [SerializeField]
    float borders = 7.25f;
    [SerializeField]
    float floorHeight = 4.75f;
    [SerializeField]
    Animator animator;
    [SerializeField]
    SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");

        animator.SetBool("IsRunning", Mathf.Abs(horizontalMove) > 0.2 ); //Si el pje se mueve (lo miro en valor absoluto pq me da igual la dirección) cambia a la animación de Running
        //0.2 me ha parecido que no tarda mucho en volver a Idle y se siente responsivo para empezar a correr

        if (Input.GetKeyDown(KeyCode.Space)) //Si se presiona el espacio que haga la animación de disparar y como es un GetKeyDown vuelve a Idle o Running
        {
            animator.SetTrigger("IsShooting"); 
        }
        else animator.ResetTrigger("IsShooting");

        if (horizontalMove != 0) //Solo invierto el sprite si el personaje se mueve, para que en quieto se quede con la horientación que tenía
        {
            spriteRenderer.flipX = horizontalMove < 0; //Si el movimiento es a la izquierda invierto el sprite
        }

        //Movement
        transform.position = new Vector3(
            // In the x axis we clamp the values between the borders (-7.25 - 7.25)
            Mathf.Clamp(transform.position.x + horizontalMove * movementSpeed * Time.deltaTime, -borders, borders) 
            // Always stays in the same y coord
            , floorHeight
            , 0f);
    }
}
