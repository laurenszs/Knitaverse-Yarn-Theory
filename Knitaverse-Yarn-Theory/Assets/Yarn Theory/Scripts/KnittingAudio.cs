using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnittingAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip knitting;
    public bool keepPlaying = true;
    public float knitSoundTimer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SoundOut());
            Invoke("AudioStopPlaying", 2.5f);
        }
    }

    void AudioStopPlaying()
    {
        audioSource.Stop();
    }
    IEnumerator SoundOut()
    {
        audioSource.PlayOneShot(knitting);

        while (keepPlaying)
        {
            audioSource.PlayOneShot(knitting);
            Debug.Log("IsPlaying");
            yield return new WaitForSeconds(knitSoundTimer);
        }
    }
}
