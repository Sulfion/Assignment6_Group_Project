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

    //set the "!" icon to enabled or false depending on amount of remaining fish at start of new "scene"
    public IEnumerator InformationCoroutine()
    {
        if(flockManager.numNPC == 30)
        {
            yield return new WaitForSeconds(7.0f);
            informationPanel.SetActive(false);
        }
        if (flockManager.numNPC == 25)
        {
            informationPanel.SetActive(true);
            yield return new WaitForSeconds(7.0f);
            informationPanel.SetActive(false);
        }
        if (flockManager.numNPC == 20)
        {
            informationPanel.SetActive(true);
            yield return new WaitForSeconds(7.0f);
            informationPanel.SetActive(false);
        }
        if (flockManager.numNPC == 15)
        {
            informationPanel.SetActive(true);
            yield return new WaitForSeconds(7.0f);
            informationPanel.SetActive(false);
        }
        if (flockManager.numNPC == 10)
        {
            informationPanel.SetActive(true);
            yield return new WaitForSeconds(7.0f);
            informationPanel.SetActive(false);
        }
        if (flockManager.numNPC == 5)
        {
            informationPanel.SetActive(true);
            yield return new WaitForSeconds(7.0f);
            informationPanel.SetActive(false);
        }
        if (flockManager.numNPC == 0)
        {
            informationPanel.SetActive(true);
            yield return new WaitForSeconds(7.0f);
            informationPanel.SetActive(false);
        }
    }
}
