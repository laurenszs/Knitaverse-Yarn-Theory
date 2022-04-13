using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateComponent : MonoBehaviour
{

    public GameObject objectCollider;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            objectCollider.gameObject.SetActive(true);
            Debug.Log("RandomLetters");
        }
        Debug.Log("Random");
    }

}