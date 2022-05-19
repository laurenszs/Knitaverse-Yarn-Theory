using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnittingAudio : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip knitting;
    public bool keepPlaying = true;
    public float knitSoundTimer = 0.3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SoundOut());
        }
    }
    IEnumerator SoundOut()
    {
        audiosource.PlayOneShot(knitting);

        while (keepPlaying)
        {
            audiosource.PlayOneShot(knitting);
            Debug.Log("IsPlaying");
            yield return new WaitForSeconds(knitSoundTimer);
        }
    }
}
