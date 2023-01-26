using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script manages the "!" icon using the scene control variables
public class Information : MonoBehaviour
{
    public GameObject informationPanel; 

    void Start()
    {
        StartCoroutine(InformationCoroutine()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator InformationCoroutine()
    {
        yield return new WaitForSeconds(10f); //10s
        informationPanel.SetActive(false); // close the information panel (or picture? TBD)
        //audio.Play(); //play prompt sound when dispear.
    }
}
