using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // Declare class variables
    private Rigidbody2D rb;
    private PolygonCollider2D self;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            rb.isKinematic = false;
        }

        if (collision.tag == "Player" || collision.tag == "Enemy")
            Destroy(collision.gameObject);
    }
}
