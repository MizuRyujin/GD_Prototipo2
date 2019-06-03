using UnityEngine;

public class GameMngr : MonoBehaviour
{

    private static GameMngr instance;
    public Vector2 LastCheckPointPos;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

}