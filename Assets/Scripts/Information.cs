using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script manages the "!" icon using the scene control variables
public class Information : MonoBehaviour
{
    public GameObject informationPanel;
    public FlockManager flockManager;

    void Start()
    {
        flockManager = GameObject.FindWithTag("FlockManager").GetComponent<FlockManager>();
        StartCoroutine(InformationCoroutine());
    }


    //set the "!" icon to false after getting users attention
    public IEnumerator InformationCoroutine()
    {
        if (flockManager.numNPC == 30)
        {
            yield return new WaitForSeconds(5.0f);
            this.gameObject.SetActive(false);

        }
    }
}
