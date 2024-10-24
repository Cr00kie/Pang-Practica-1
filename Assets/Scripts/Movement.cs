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
    SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        //Movement
        transform.position = new Vector3(
            // In the x axis we clamp the values between the borders (-7.25 - 7.25)
            Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, -borders, borders) 
            // Always stays in the same y coord
            , floorHeight
            , 0f);

        if (Input.GetAxis("Horizontal") > 0) { spriteRenderer.flipX = true; }
        if (Input.GetAxis("Horizontal") < 0) { spriteRenderer.flipX = false; }

    }
}
