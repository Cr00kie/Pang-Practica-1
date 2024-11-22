using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed = 15f;
    [SerializeField]
    float heightLimit = 9;
    

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * bulletSpeed * Time.deltaTime;

        if (transform.position.y > heightLimit)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Blowup script = collision.gameObject.GetComponent<Blowup>();
        if (script != null)
        {
            script.Burst();
            Destroy(gameObject);
        }
    }
}
