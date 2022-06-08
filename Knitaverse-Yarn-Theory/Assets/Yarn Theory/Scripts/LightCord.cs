using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCord : MonoBehaviour
{
    public AudioClip lightCordOn;
    public AudioSource audioSource;

    public void PlaySound()
    {
        if (!audioSource) return;
        audioSource.PlayOneShot(lightCordOn);
    }
}
