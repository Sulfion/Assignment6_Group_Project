using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public ParticleSystem collectedEffect;

    public void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == ("Box"))
        {
            collectedEffect.Play();
        }
    }
}
