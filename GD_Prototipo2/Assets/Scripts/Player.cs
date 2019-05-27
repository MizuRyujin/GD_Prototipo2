using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Declare instace
    [SerializeField] private float moveSpeed;
    [SerializeField] private float height;
    [SerializeField] private int nJumps;

    private Animator anim;

    Rigidbody2D rb;

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

    private void Movement()
    {
        float hAxis = Input.GetAxis("Horizontal");
        Vector2 movement = rb.velocity;

        movement = new Vector2(hAxis * moveSpeed, movement.y);

        float rotate = hAxis * transform.right.x;

        if (rotate < 0.0f)
        {
            float rotAngle = 180.0f;

            transform.rotation = transform.rotation *
                Quaternion.Euler(0.0f, rotAngle, 0.0f);
        }

        if (Input.GetKeyDown("space"))
        {
            Debug.Log("I'm trying to jump");

            if (isOnGround && nJumps >= 0)
            {
                Debug.Log("I'm on ground - I can jump");
                movement.y = height;
                nJumps--;
            }

            nJumps = 2;
        }

        anim.SetFloat("Speed", Mathf.Abs(movement.x));
        rb.velocity = movement;
    }

    private bool isOnGround
    {
        get
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, 2.0f,
            LayerMask.GetMask("Ground"));
            return collider != null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 2.0f);
    }
}
