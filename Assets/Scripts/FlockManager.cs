using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FlockManager : MonoBehaviour
{
    public GameObject npcPrefab;

    public Transform respawnTransform;

    public int numNPC = 30;
    public GameObject[] allNPC;
    public Vector3 spawnLimit = new Vector3(30, 0, 30);

    [Range(1.0f, 10.0f)]
    public float neighbourDistance;
    [Range(0.0f, 5.0f)]
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnGroupAndStorePositions());
    }

    // Update is called once per frame
    void Update()
    {

    }


    //spawn specified number of NPCs and store their positions in an array.
    //Also where they spawn so they don't appear off the map
    //coroutine used to regulate fish spawn speed
    IEnumerator SpawnGroupAndStorePositions()
    {
        allNPC = new GameObject[numNPC];
        for (int i = 0; i < numNPC; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-spawnLimit.x, spawnLimit.y),
                                                                Random.Range(-spawnLimit.y, spawnLimit.y),
                                                                Random.Range(-spawnLimit.z, spawnLimit.z));
            allNPC[i] = (GameObject)Instantiate(npcPrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    }
}

