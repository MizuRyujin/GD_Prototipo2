using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearOnTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().hp--;
            Destroy(gameObject);
        }

        if (collision.tag == "Wall" || collision.tag == "Ground" || collision.tag == "Ceilling")
            Destroy(gameObject);
    }
}
