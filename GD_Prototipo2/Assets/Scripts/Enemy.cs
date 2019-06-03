using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Declare instance variables
    [SerializeField] private float moveSpeed;


    private Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = rb.velocity;
        movement.x = -transform.right.x * moveSpeed;
        rb.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Wall")
            rb.velocity = transform.right * moveSpeed;
            transform.rotation = transform.rotation * Quaternion.Euler(0f, 180f, 0f);

        if(collision.collider.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
