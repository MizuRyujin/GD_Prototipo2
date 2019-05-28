using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agent
{
    public Player()
    {
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
        //Jump();
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
