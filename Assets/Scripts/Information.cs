using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
    public GameObject informationPanel; //just a example, we can have informationLevel1 and informationLevel2 if needed.
    private new AudioSource audio;
    void Start()
    {
        //audio = GetComponent<AudioSource>(); // get the Audio source component

        StartCoroutine(InformationCoroutine()); // start a time down
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
