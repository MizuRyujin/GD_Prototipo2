using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Instance variables
    public float stillTime;

    // Class variables
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        stillTime -= Time.deltaTime;

        if(stillTime <= 0)
        {
            rb.isKinematic = false;
        }
    }
}
