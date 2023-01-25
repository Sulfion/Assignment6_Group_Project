using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BookPageManager : MonoBehaviour
{
    public Texture[] textures;
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        TurnThePage();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TurnThePage()
    {

        rend.material.mainTexture = textures[0];
    }
}
