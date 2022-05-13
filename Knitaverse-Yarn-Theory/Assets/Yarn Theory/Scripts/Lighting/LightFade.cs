using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFade : MonoBehaviour
{
    [SerializeField] private GameObject lightContainer;
    [SerializeField] private float fadeSpeed;
    [SerializeField] private bool fadeActivate = false;
    private bool negative = false;
    public float fadeMultiplier = 0f;
    public Light[] lightList;

    // Start is called before the first frame update
    void Start()
    {
        lightList = lightContainer.GetComponentsInChildren<Light>();
        foreach (var t in lightList)
        {
            t.intensity *= fadeMultiplier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeActivate)
        {
            ActivateFade(fadeSpeed);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Debug.Log("stuff is working");
        foreach (var t in lightList)
        {
            t.intensity *= fadeMultiplier;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (fadeMultiplier is < 1 or >= 0)
        {
            fadeMultiplier += fadeSpeed;
        }

        foreach (var t in lightList)
        {
            t.intensity *= fadeMultiplier;
        }
    }

    private void ActivateFade(float fSpeed)
    {
        if (fadeMultiplier is < 1 or >= 0)
        {
            if (negative) fadeMultiplier -= fSpeed;
            else fadeMultiplier -= fSpeed;
        }
    }
}