using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFade : MonoBehaviour
{
    public static LightFade Instance;
    [SerializeField] private GameObject lightContainer;
    [SerializeField] [Range(0, .1f)] private float fadeSpeed = .001f;
    [Range(0, 1)] public float fadeCompletion;
    public Light[] lightList;
    public List<float> intensityValue;
    private bool triggered;

    private void Start()
    {
        Instance = this;
        lightList = lightContainer.GetComponentsInChildren<Light>();
        if (lightList == null) return;
        foreach (var lightInt in lightList)
        {
            intensityValue.Add(lightInt.intensity);
        }
    }

    private void Update()
    {
        for (int i = 0; i < lightList.Length; i++)
        {
            lightList[i].intensity = intensityValue[i] * fadeCompletion;
        }

        if (triggered)
        {
            if (fadeCompletion <= 1) fadeCompletion += fadeSpeed;
        }
        else
        {
            if (fadeCompletion >= 0) fadeCompletion -= fadeSpeed;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        triggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        triggered = false;
    }
}