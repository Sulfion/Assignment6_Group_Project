using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.GraphicsBuffer;

public class FishGoalPositionController : MonoBehaviour
{
    public FlockManager flockManager;
    public FadeScreen fadeScreen;

    public GameObject thisGameObject;
    private Vector3 originalScale;
    private Vector3 flatScale;
    private Vector3 flatScaleTwo;

    GameObject[] goalLocationsOne;
    GameObject[] goalLocationsTwo;
    GameObject[] goalLocationsThree;
    GameObject[] goalLocationsFour;
    GameObject[] goalLocationsFive;
    NavMeshAgent agent;

    private bool dontStop = true;
    public bool atEnd = false;
    private int goalCompleteTracker = 0;
    public int currentLevelTracker = 0;
    private int stopIfStatement = 0;

    // Start is called before the first frame update
    void Start()
    {
        flockManager = GameObject.FindWithTag("FlockManager").GetComponent<FlockManager>();
        fadeScreen = GameObject.FindWithTag("FaderScreen").GetComponent<FadeScreen>();
        
        originalScale = thisGameObject.transform.localScale;
        flatScale = new Vector3 (originalScale.x * 0.80f, originalScale.y * 0.80f, originalScale.z * 0.80f); //these are used to change the scale of the fish to be smaller
        flatScaleTwo = new Vector3(originalScale.x * 0.50f, originalScale.y * 0.50f, originalScale.z * 0.50f);

        SetStartGoalForAgentsAndArrays();
        StartCoroutine(RandomMoveSpeed());
    }

    private void Update()
    {
        SetFishNewGoal();
        CurrentLevelTracker();
    }

    //initialize arrays for different stages of progression down the river
    private void SetStartGoalForAgentsAndArrays()
    {
        goalLocationsOne = GameObject.FindGameObjectsWithTag("Goal");
        goalLocationsTwo = GameObject.FindGameObjectsWithTag("GoalTwo");
        goalLocationsThree = GameObject.FindGameObjectsWithTag("GoalThree");
        goalLocationsFour = GameObject.FindGameObjectsWithTag("GoalFour");
        goalLocationsFive = GameObject.FindGameObjectsWithTag("GoalFive");
        agent = this.GetComponent<NavMeshAgent>();
    }

    //check if at end of river
    //if true, reset to initial values, and change position back to start of river
    public void CheckIfAtEnd()
    {
        if (atEnd == true)
        {
            goalCompleteTracker = 0;
            atEnd = false;
            agent.enabled = false;
            thisGameObject.transform.position = flockManager.respawnTransform.position;
            agent.enabled = true;
        }
    }

    //track when fish reaches a goal by distance with variable to know which goal has been reached
    //when goal has been reached, choose a random new goal from the next arrays positions
    //destroy gameobject when final goal reached
    private void SetFishNewGoal()
    {
        switch (goalCompleteTracker)
        {
            case 0:
                if (agent.remainingDistance < 1)
                {
                    agent.SetDestination(goalLocationsOne[Random.Range(0, goalLocationsOne.Length)].transform.position);
                    goalCompleteTracker++;
                }
                break;
            case 1:
                if (agent.remainingDistance < 1)
                {
                    agent.SetDestination(goalLocationsTwo[Random.Range(0, goalLocationsTwo.Length)].transform.position);
                    goalCompleteTracker++;
                }
                break;
            case 2:
                if (agent.remainingDistance < 1)
                {
                    agent.SetDestination(goalLocationsThree[Random.Range(0, goalLocationsThree.Length)].transform.position);
                    goalCompleteTracker++;
                }
                break;
            case 3:
                if (agent.remainingDistance < 1)
                {
                    agent.SetDestination(goalLocationsFour[Random.Range(0, goalLocationsFour.Length)].transform.position);
                    goalCompleteTracker++;
                }
                break;
            case 4:
                if (agent.remainingDistance < 1)
                {
                    agent.SetDestination(goalLocationsFive[Random.Range(0, goalLocationsFive.Length)].transform.position);
                    goalCompleteTracker++;
                }
                break;
            case 5:
                if (agent.remainingDistance < 1)
                {
                    atEnd = true;
                    CheckIfAtEnd();
                }
                break;
        }
    }


    //randomly change the movement speed of each NPC with random timing
    IEnumerator RandomMoveSpeed()
    {
        while (dontStop == true)
        {
            GetComponent<NavMeshAgent>().speed = Random.Range(10.0f, 10.0f); //set a random speed for each agent
            yield return new WaitForSeconds(Random.Range(8.0f, 20.0f));
        }
    }

    //remove the fish when it's put in the box
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
        {
            agent.enabled = false;
            thisGameObject.gameObject.SetActive(false);
            flockManager.numNPC--; //track how many fish removed by putting in box

        }
    }

    //method to control transition variables between levels for FadeScreen script
    public void CurrentLevelTracker()
    {
        if (flockManager.numNPC == 30 && stopIfStatement == 0)
        {
            currentLevelTracker++;
            stopIfStatement++;
        }
        if (flockManager.numNPC == 26 && stopIfStatement == 1)
        {
            thisGameObject.transform.localScale = flatScale; //when certain amount of fish are caught, reduce the size
            currentLevelTracker++;
            stopIfStatement++;
        }
        if (flockManager.numNPC == 21 && stopIfStatement == 2)
        {
            currentLevelTracker++;
            stopIfStatement++;
        }
        if (flockManager.numNPC == 17 && stopIfStatement == 3)
        {
            thisGameObject.transform.localScale = flatScaleTwo;
            currentLevelTracker++;
            stopIfStatement++;
        }
        if (flockManager.numNPC == 13 && stopIfStatement == 4)
        {
            currentLevelTracker++;
            stopIfStatement++;
        }
        if (flockManager.numNPC == 9 && stopIfStatement == 5)
        {
            currentLevelTracker++;
            stopIfStatement++;
        }
        if (flockManager.numNPC == 5 && stopIfStatement == 6)
        {
            currentLevelTracker++;
            stopIfStatement++;
        }
    }
}
