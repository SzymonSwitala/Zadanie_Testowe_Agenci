using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject agentPrefab;
    [Range(1, 30)] [SerializeField] private int maxAgents;
    [SerializeField] private float minAgentSpawnTime;
    [SerializeField] private float maxAgentSpawnTime;
    
    public void StartSpawning()
    {
        CreateAgent();
    }

    public void CreateAgent()
    {
        int randomXPosition = Random.Range(0,10);
        int randomZPosition = Random.Range(0, 10);
        Vector3 pos = new Vector3(randomXPosition, 0, randomZPosition);
        Instantiate(agentPrefab,pos,Quaternion.identity);

    }
}
