using System.Collections;
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
        StartCoroutine(Spawning());


    }
    private IEnumerator Spawning()
    {
        while (transform.childCount >= maxAgents)
        {
            yield return new WaitForEndOfFrame();
        }

        float randomSpawnTime = Random.Range(minAgentSpawnTime, maxAgentSpawnTime);
        yield return new WaitForSeconds(randomSpawnTime);
        CreateAgent();
        StartCoroutine(Spawning());
    }
    public void CreateAgent()
    {
        int randomXPosition = Random.Range(0,9);
        int randomZPosition = Random.Range(0, 9);
        Vector3 pos = new Vector3(randomXPosition, 0, randomZPosition);
        Instantiate(agentPrefab,pos,Quaternion.identity);

    }
}
