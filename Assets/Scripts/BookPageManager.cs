using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BookPageManager : MonoBehaviour
{
    public FlockManager flockManager;
    public GameObject bearModel;

    public Texture[] texturesOne;
    public Renderer rendOne;

    // Start is called before the first frame update
    void Start()
    {
        flockManager = GameObject.FindWithTag("FlockManager").GetComponent<FlockManager>();
        rendOne = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        TurnThePage();

        if (flockManager.numNPC == 10)
        {
            bearModel.SetActive(false);
        }
    }

    //manage the book pages, when enough fish are caught update the text and picture
    public void TurnThePage()
    {
        if(flockManager.numNPC == 30)
        {
            rendOne.material.mainTexture = texturesOne[0];
        }
        if (flockManager.numNPC == 25)
        {
            rendOne.material.mainTexture = texturesOne[1];
        }
        if (flockManager.numNPC == 20)
        {
            rendOne.material.mainTexture = texturesOne[2];
        }
        if (flockManager.numNPC == 15)
        {
            rendOne.material.mainTexture = texturesOne[3];
        }
        if (flockManager.numNPC == 10)
        {
            rendOne.material.mainTexture = texturesOne[4];
        }
        if (flockManager.numNPC == 5)
        {
            rendOne.material.mainTexture = texturesOne[5];
        }
        if (flockManager.numNPC == 0)
        {
            rendOne.material.mainTexture = texturesOne[6];
        }
    }
}
