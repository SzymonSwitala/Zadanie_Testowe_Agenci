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

        Move();
        yield return new WaitForSeconds(moveCooldown);
        StartCoroutine(Moving());
    }

    void Move()
    {
        Directions randomDirection = (Directions)Random.Range(0, 4);
        Vector3 newPosition = transform.position;

        if (randomDirection == Directions.North)
        {
            newPosition += new Vector3(0, 0, 1);
        }
        else if (randomDirection == Directions.South)
        {
            newPosition += new Vector3(0, 0, -1);
        }
        else if (randomDirection == Directions.West)
        {
            newPosition += new Vector3(-1, 0, 0);
        }
        else if (randomDirection == Directions.East)
        {
            newPosition += new Vector3(1, 0, 0);
        }

        if (!IsOnBoard(newPosition))
        {
            Debug.Log("Agent want to move outside board's border");
          Move();
            return;
        }

        transform.position = newPosition;


    }

    private bool IsOnBoard(Vector3 newPosition)
    {
        if (newPosition.x<0||newPosition.z<0||newPosition.x>9||newPosition.z>9)
        {
            return false;
        }
        else
        {
            return true;
        }
    }



}
