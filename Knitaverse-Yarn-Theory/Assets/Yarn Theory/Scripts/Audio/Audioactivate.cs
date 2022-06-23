using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audioactivate : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip knitting;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(knitting);
        }
    }
}
