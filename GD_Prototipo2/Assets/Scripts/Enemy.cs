﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Declare instance variables
    [SerializeField] private float moveSpeed;
    public int hp;


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

        if (hp == 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Wall")
            rb.velocity = transform.right * moveSpeed;
            transform.rotation = transform.rotation * Quaternion.Euler(0f, 180f, 0f);

        if(collision.collider.tag == "Player")
        {
            Player plr = collision.gameObject.GetComponent<Player>();
            Vector3 knockback = collision.transform.position - transform.position;
            float force = 1500.0f;

            plr.hp--;

            plr.gameObject.GetComponent<Rigidbody2D>().AddForce(
                force * knockback.normalized);

            print("I'm knocking back and taking hp");


        }
    }
}
