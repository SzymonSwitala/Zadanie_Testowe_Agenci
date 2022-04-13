using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public Spawner spawner;
    public Informations informations;
    private void Start()
    {
        spawner.StartSpawning();
    }
    private void Update()
    {
        Inputs();


    }
    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetMouseButtonDown(1))
        {
            informations.UnselectAgent();
        }
    }
}
