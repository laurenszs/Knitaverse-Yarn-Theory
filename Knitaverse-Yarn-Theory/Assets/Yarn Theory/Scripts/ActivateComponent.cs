using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateComponent : MonoBehaviour
{

    public GameObject tunnelPrefab;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))

        tunnelPrefab.gameObject.SetActive(true);

    }

}