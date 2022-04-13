using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    [SerializeField] private string agentName;
    [SerializeField] private int healthPoints = 3;
    [SerializeField] private float moveCooldown;
    enum Directions
    {
        North,
        South,
        East,
        West
    }

    private void Start()
    {
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        Vector3 randomDirection = RandomDirection();
        while (IsOnBoard(randomDirection + transform.position) == false)
        {
            randomDirection = RandomDirection();
        }

        Vector3 tempAgentPosition = transform.position;

        while (transform.position != randomDirection + tempAgentPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, randomDirection + tempAgentPosition, Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(moveCooldown);
        StartCoroutine(Moving());
    }
    private Vector3 RandomDirection()
    {
        Directions randomDirection = (Directions)Random.Range(0, 4);
        Vector3 newDirection = Vector3.zero;

        if (randomDirection == Directions.North)
        {
            newDirection = new Vector3(0, 0, 1);
        }
        else if (randomDirection == Directions.South)
        {
            newDirection = new Vector3(0, 0, -1);
        }
        else if (randomDirection == Directions.West)
        {
            newDirection = new Vector3(-1, 0, 0);
        }
        else if (randomDirection == Directions.East)
        {
            newDirection = new Vector3(1, 0, 0);
        }

        return newDirection;

    }

    private bool IsOnBoard(Vector3 newPosition)
    {
        if (newPosition.x < 0 || newPosition.z < 0 || newPosition.x > 9 || newPosition.z > 9)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GetHealthPoint();
    }

    public void GetHealthPoint()
    {
        healthPoints--;
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

}
