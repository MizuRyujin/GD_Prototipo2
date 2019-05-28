using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    // Agents' variables
    [SerializeField] protected float    height;
    [SerializeField] protected int      nJumps;
    [SerializeField] protected int      aJumps;
    [SerializeField] protected float    moveSpeed = 100;

    public Animator     anim;
    public Rigidbody2D  rb;
    public Collider2D   colliderGround;
    public Collider2D   colliderAir;

    // Properties   

    // On ground checker
    protected bool isOnGround
    {
        get
        {
            colliderGround = Physics2D.OverlapCircle(transform.position, 2.0f,
            LayerMask.GetMask("Ground"));
            return colliderGround != null;
        }
    }

    // Controls movement
    protected void Movement()
    {
        // Variables
        float hAxis = Input.GetAxis("Horizontal");
        float rotate = hAxis * transform.right.x;
        Vector2 movement = rb.velocity;

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

            // || isOnAir && aJumps >= 0
            while (isOnGround && nJumps >= 0)
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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string ToString()
    {
        return base.ToString();
    }

}
