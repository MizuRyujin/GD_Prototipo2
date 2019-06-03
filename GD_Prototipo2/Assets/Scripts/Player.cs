using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Declare instance variables
    [SerializeField] private float                      moveSpeed;
    [SerializeField] private float                      height;
    [SerializeField] private Transform spawn;
    private BoxCollider2D                               airColl;
    private CapsuleCollider2D                           groundColl;
    private float                                       nJumps = 2;
    private Animator                                    anim;
    private Rigidbody2D                                 rb;


    // Properties (read-only)
    // If character is on ground
    private bool isOnGround
    {
        get
        {
            Collider2D Ground = Physics2D.OverlapCircle(transform.position, 2.0f,
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
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

            //Check if player can double jump
            if (nJumps > 0)
            {
                Debug.Log($"I'm on air - I can jump, nJumps{nJumps}");
                groundColl.enabled = false;
                airColl.enabled = true;
                movement.y = height;
                nJumps--;
            }

            //Check if player already used double jump
            if (nJumps == 0 && isOnGround)
            {
                Debug.Log($"I'm on ground && I can jump, nJumps{nJumps}");
                movement.y = height;

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
