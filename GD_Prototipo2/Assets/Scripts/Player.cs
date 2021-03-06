﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Declare instance variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float height;
    [SerializeField] private Transform spawn;
    public int hp;


    // Declare class variables
    private BoxCollider2D airColl;
    private CapsuleCollider2D groundColl;
    private float nJumps;
    private Animator anim;
    private Rigidbody2D rb;
    public int timeMode;
    private float doubleSpeed;
    private float normalSpeed;
    private float normalHeight;
    private float doubleHeight;

    // Properties (read-only)
    // If character is on ground
    private bool isOnGround
    {
        get
        {
            Collider2D Ground = Physics2D.OverlapCircle(transform.position, 15.0f,
            LayerMask.GetMask("Ground"));
            return Ground != null;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundColl = GetComponent<CapsuleCollider2D>();
        airColl = GetComponent<BoxCollider2D>();
        transform.position = spawn.position;
        timeMode = 0;
        doubleSpeed = moveSpeed * 1.5f;
        normalSpeed = moveSpeed;
        normalHeight = height;
        doubleHeight = height * 1.5f;
        nJumps = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        print(isOnGround);
        Movement();

        if (Input.GetButtonDown("Fire3"))
        {
            if (Time.timeScale != 1)
            {
                Time.timeScale = 1f;
                timeMode = 0;
                moveSpeed = normalSpeed;
            }

            else
            {
                timeMode = 1;
                Time.timeScale = 0.3f;
                moveSpeed = doubleSpeed;
            }
        }

        if (hp == 0)
            Destroy(gameObject);
    }


    // Controls movement
    private void Movement()
    {
        // Block variables
        float hAxis = Input.GetAxis("Horizontal");
        Vector2 movement = rb.velocity;

        // Actual movement
        movement = new Vector2(hAxis * moveSpeed, movement.y);

        // Rotation
        float rotate = hAxis * transform.right.x;
        if (rotate < 0.0f)
        {
            float rotAngle = 180.0f;

            transform.rotation = transform.rotation *
                Quaternion.Euler(0.0f, rotAngle, 0.0f);
        }

        // In case player press space, jump
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("I'm trying to jump");

            //Check if player already used double jump
            if (isOnGround)
            {
                Debug.Log($"I'm on ground && I can jump, nJumps{nJumps}");
                movement.y = height;
                nJumps = 1;

                if (timeMode == 0)
                    movement.y = normalHeight;

            }

            //Check if player can double jump
            if (nJumps > 0)
            {
                Debug.Log($"I'm on air - I can jump, nJumps{nJumps}");
                groundColl.enabled = false;
                airColl.enabled = true;
                movement.y = height;
                --nJumps;

                if (timeMode == 1)
                    movement.y = doubleHeight;
            }


        }

        // Reset number of allowed jumps
        if (isOnGround)
        {
            nJumps = 2;
            groundColl.enabled = true;
            airColl.enabled = false;
        }

        anim.SetFloat("Speed", Mathf.Abs(movement.x));
        rb.velocity = movement;
    }



    // Gizmos! //
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 2.0f);
    }

    /*
     A cena do air jump vê lá se percebes,
     a lógica é, caso ele não detete colisão por baixo
     com o collider, ele salta caso tiver aJumps (air juumps) > 0
     */

}

