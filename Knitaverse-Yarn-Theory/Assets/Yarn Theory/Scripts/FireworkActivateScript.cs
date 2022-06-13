using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkActivateScript : MonoBehaviour
{
    public GameObject[] activateComponent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < activateComponent.Length; i++)
            {
                activateComponent[i].gameObject.SetActive(true);
            }
        }
    }
}
