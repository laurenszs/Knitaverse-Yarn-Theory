using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnitOnboarding : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip knitting;
    public bool keepPlaying = true;
    public float knitSoundTimer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SoundOut());
        Invoke("AudioStopPlaying", 3.0f);
    }

    void AudioStopPlaying()
    {
        keepPlaying = false;
    }

    IEnumerator SoundOut()
    {
        yield return new WaitForSeconds(0.5f);

        audioSource.PlayOneShot(knitting);

        while (keepPlaying)
        {
            audioSource.PlayOneShot(knitting);
            Debug.Log("IsPlaying");
            yield return new WaitForSeconds(knitSoundTimer);
        }
    }
}
