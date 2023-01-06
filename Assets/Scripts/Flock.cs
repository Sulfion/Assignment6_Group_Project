using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockManager flockManager;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(flockManager.minSpeed, flockManager.maxSpeed); //set speed of fish using values from flock manager
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) < 10)
        {
            speed = Random.Range(flockManager.minSpeed,
                                 flockManager.maxSpeed);
        }
        if(Random.Range(0, 100) < 20)
        {
            ApplyRules();
        }

        transform.Translate(-(Time.deltaTime * speed), 0.0f, 0.0f); //move the fish forward
    }

    //hold all the fish in current flock
    //calculate average center of group
    //calculate average avoidance vector
    //find the average speed the group is moving in
    //calculate how far each fish is away from each other and keep track of how many fish are a part of this group
    void ApplyRules()
    {
        GameObject[] gos;
        gos = flockManager.allFish;

        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.01f;
        float nDistance;
        int groupSize = 0;

        foreach (GameObject go in gos)
        {
            if (go != this.gameObject) //don't calculate for itself
            {
                nDistance = Vector3.Distance(go.transform.position, this.transform.position);
                if (nDistance <= flockManager.neighbourDistance)
                {
                    vcentre += go.transform.position;
                    groupSize++;

                    if (nDistance < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }

                    Flock anotherFlock = go.GetComponent<Flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }

        if (groupSize > 0) //if there's another fish in the group, find the average center and speed to calculate the direction it should go in
        {
            vcentre = vcentre / groupSize + (flockManager.goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            Vector3 direction = (vcentre + vavoid) - transform.position;
            if (direction != Vector3.zero)

                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                      Quaternion.LookRotation(direction),
                                                      flockManager.rotationSpeed * Time.deltaTime);
        }
    }
}
