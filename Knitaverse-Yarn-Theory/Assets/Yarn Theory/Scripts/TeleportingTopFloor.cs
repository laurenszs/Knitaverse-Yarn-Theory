using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingTopFloor : MonoBehaviour
{
    public Transform player;
    public Transform teleportPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TeleportationPoint();
        }
    }
    public void TeleportationPoint()
    {
        player.transform.position = teleportPosition.transform.position;
    }
 }
