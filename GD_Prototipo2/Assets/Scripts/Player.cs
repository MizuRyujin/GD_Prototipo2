using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agent
{
    // Declare instace
    // Variables
    [SerializeField] private float  moveSpeed;
    [SerializeField] private float  height;
    [SerializeField] private int    nJumps;
    [SerializeField] private int    aJumps;
    private Animator                anim;
    Rigidbody2D                     rb;
    Collider2D                      colliderGround;
    Collider2D                      colliderAir;

    // Properties
    // On ground checker
    private bool isOnGround
    {
        get
        {
            colliderGround = Physics2D.OverlapCircle(transform.position, 2.0f,
            LayerMask.GetMask("Ground"));
            return colliderGround != null;
        }
    }

    // On air checker
    private bool isOnAir
    {
        get
        {
            colliderAir = Physics2D.OverlapCircle(transform.position, 2.0f,
            LayerMask.GetMask("Air"));
            return colliderAir = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    // Controls movement
    private void Movement()
    {
        // Variables
        float       hAxis = Input.GetAxis("Horizontal");
        float       rotate = hAxis * transform.right.x;
        Vector2     movement = rb.velocity;

        movement = new Vector2(hAxis * moveSpeed, movement.y);

        if (rotate < 0.0f)
        {
            float rotAngle = 180.0f;

            transform.rotation = transform.rotation *
                Quaternion.Euler(0.0f, rotAngle, 0.0f);
        }

        // Case player press' space, jump
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("I'm trying to jump");

            //
            while (isOnGround && nJumps >= 0 || isOnAir && aJumps >= 0)
            {
                Debug.Log("I'm on ground - I can jump");
                movement.y = height;
                nJumps--;
            }

            nJumps = 1;
            aJumps = 1;
        }

        anim.SetFloat("Speed", Mathf.Abs(movement.x));
        rb.velocity = movement;
    }

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
