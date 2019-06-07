using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearOnTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall" 
            || collision.tag == "Ground" 
            || collision.tag == "Ceilling"  
            || collision.tag == "Player")
            Destroy(gameObject);
    }
}
