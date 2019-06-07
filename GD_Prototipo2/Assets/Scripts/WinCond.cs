using UnityEngine;

public class WinCond : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Player won!!!");
        if(other.tag == "Player")
        {
            Application.Quit();
        }
    }
}
