using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingTopFloor : MonoBehaviour
{
    public Transform player;
    public Transform teleportPosition;
    public AudioSource audioSource;
    public AudioClip teleporting;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TeleportDelay());

        }
    }
    public void TeleportationPoint()
    {
        player.transform.position = teleportPosition.transform.position;
    }

    IEnumerator TeleportDelay()
    {
        audioSource.PlayOneShot(teleporting);
        yield return new WaitForSeconds(1.5f);
        TeleportationPoint();
    }
}
