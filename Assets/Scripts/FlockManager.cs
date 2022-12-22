using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject fishPrefab;
    public int numberOfFish = 20;
    public GameObject[] allFish;
    public Vector3 swimLimits = new Vector3(5.0f, 5.0f, 5.0f);
    public GameObject goalPositionObject;
    public Vector3 goalPos;

    [Header("Fish Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(0.0f, 20.0f)]
    public float neighbourDistance;
    [Range(0.0f, 30.0f)]
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        SpawnFishSetLimits();
    }

    //instantiate all fish objects into an array, and puts them at a random position inside the set limit
    void SpawnFishSetLimits()
    {
        allFish = new GameObject[numberOfFish];
        for (int i = 0; i < numberOfFish; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
                                                                Random.Range(-swimLimits.x, swimLimits.x),
                                                                Random.Range(-swimLimits.x, swimLimits.x));
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
            allFish[i].GetComponent<Flock>().flockManager = this;               //link flock and flock manager together
        }
        goalPos = goalPositionObject.transform.position;
    }

    private void Update()
    {
        goalPos = goalPositionObject.transform.position;
    }
}
