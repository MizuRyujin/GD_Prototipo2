using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartMngr : MonoBehaviour
{

    private Scene Scene;
    public GameObject LevelStart;

    private GameMngr gm;

    private void Awake()
    {
        gameObject.transform.position = LevelStart.transform.position;
    }

    void Start()
    {
        Scene = SceneManager.GetActiveScene();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMngr>();
        transform.position = gm.LastCheckPointPos;
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(Scene.name);
        }
    }

}
