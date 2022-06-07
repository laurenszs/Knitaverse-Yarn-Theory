using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCord : MonoBehaviour
{
    public AudioClip lightCordOn;

    public void PlaySound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(lightCordOn);
    }
}
