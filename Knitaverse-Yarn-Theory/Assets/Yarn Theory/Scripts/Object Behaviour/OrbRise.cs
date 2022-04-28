using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbRise : MonoBehaviour
{
    [SerializeField] private List<RiseUp> orblist;
    [SerializeField] private GameObject spawners;

    private void Start()
    {
        foreach (var orb in GetComponentsInChildren<RiseUp>())
        {
            orblist.Add(orb);
        }
    }

    private void Update()
    {
        //remove after testing
        if (Input.GetKeyDown(KeyCode.P))
        {
            foreach (var t in orblist)
            {
                t.MoveUp();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        spawners.SetActive(true);
        foreach (var t in orblist)
        {
            t.MoveUp();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        spawners.SetActive(false);
        foreach (var t in orblist)
        {
            t.MoveDown();
        }
    }
}