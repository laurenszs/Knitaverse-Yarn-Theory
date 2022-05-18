using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPulsingSound : MonoBehaviour
{
    public AudioClip pulsing;
    public int pulse = 1;
    public bool keepPlaying = true;
    public AudioSource audioSource;

    void Start()
    {
        Debug.Log("Start");

        StartCoroutine(SoundOut());

    }

    IEnumerator SoundOut()
    {
        audioSource.PlayOneShot(pulsing);

        while (keepPlaying)
        {
            audioSource.PlayOneShot(pulsing);
            Debug.Log("IsPlaying");
            yield return new WaitForSeconds(pulse);
        }
    }

   public void ChangePlayingState(bool state)
    {
        keepPlaying = state;
    }
}