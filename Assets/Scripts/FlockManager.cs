using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject npcPrefab;
    public int numNPC = 20;
    public GameObject[] allNPC;
    public Vector3 spawnLimit = new Vector3(30, 0, 30);

    [Range(1.0f, 10.0f)]
    public float neighbourDistance;
    [Range(0.0f, 5.0f)]
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        SpawnGroupAndStorePositions();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyRules();
    }

    //spawn specified number of NPCs and store their positions in an array.
    //Also where they spawn so they don't appear off the map
    private void SpawnGroupAndStorePositions()
    {
        allNPC = new GameObject[numNPC];
        for (int i = 0; i < numNPC; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-spawnLimit.x, spawnLimit.y),
                                                                Random.Range(-spawnLimit.y, spawnLimit.y),
                                                                Random.Range(-spawnLimit.z, spawnLimit.z));
            allNPC[i] = (GameObject)Instantiate(npcPrefab, pos, Quaternion.identity);
        }
    }

    //loop through each NPC, find it's position and figure out how much they should avoid each other
    //check if there's other NPC's around, if there is apply this rule to calculate the center
    //this calculation will then find the direction the NPC wants to travel in and rotate them them towards it
    private void ApplyRules()
    {
        GameObject[] gos;
        gos = allNPC;

        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float nDistance;
        int groupSize = 0;

        foreach (GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                nDistance = Vector3.Distance(go.transform.position, this.transform.position);
                if (nDistance <= neighbourDistance)
                {
                    vcentre += go.transform.position;
                    groupSize++;

                    if (nDistance < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position = go.transform.position);
                    }
                }
            }
        }

        if (groupSize > 0)
        {
            vcentre = vcentre / groupSize;

            Vector3 direction = (vcentre + vavoid) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                      Quaternion.LookRotation(direction),
                                                      rotationSpeed * Time.deltaTime);
        }
    }
}

