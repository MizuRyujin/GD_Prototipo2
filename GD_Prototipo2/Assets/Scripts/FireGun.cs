
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
            gameObject.GetComponent<WeaponController>().enabled = true;
    }
    public void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
            gameObject.GetComponent<WeaponController>().enabled = false;
    }

}