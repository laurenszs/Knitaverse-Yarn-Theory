using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room5KnittingAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip knitting;
    public bool keepPlaying = true;
    public float knitSoundTimer;
    public GameObject secondTunnel;
    public GameObject thirdTunnel;
    public GameObject fourthTunnel;
    public float audioInterval = 6f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SoundOut());
            Invoke("AudioStopPlaying", audioInterval);

        }
    }

    void AudioStopPlaying()
    {
        keepPlaying = false;
        GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
    }

    IEnumerator SoundOut()
    {
        while (keepPlaying)
        {
            audioSource.PlayOneShot(knitting);
            yield return new WaitForSeconds(knitSoundTimer);
        }
    }

}
