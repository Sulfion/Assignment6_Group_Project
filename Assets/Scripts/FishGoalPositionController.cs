using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishGoalPositionController : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    private bool dontStop = true;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomGoalForAgents();
        StartCoroutine(RandomMoveSpeed());
    }

    private void Update()
    {
        SetNewRandomGoalForAgents();
    }

    private void SetRandomGoalForAgents()
    {
        goalLocations = GameObject.FindGameObjectsWithTag("Goal");
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
    }

    //once the NPC reaches their goal, set a random new goal
    private void SetNewRandomGoalForAgents()
    {
        if (agent.remainingDistance < 1)
        {
            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
    }

    //randomly change the movement speed of each NPC with random timing
    IEnumerator RandomMoveSpeed()
    {
        while (dontStop == true)
        {
            GetComponent<NavMeshAgent>().speed = Random.Range(1.0f, 5.0f); //set a random speed for each agent
            yield return new WaitForSeconds(Random.Range(8.0f, 20.0f));
        }
    }
}
