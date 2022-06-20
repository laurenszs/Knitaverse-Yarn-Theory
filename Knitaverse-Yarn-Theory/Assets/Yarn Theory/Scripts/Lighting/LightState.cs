using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightState : MonoBehaviour
{
    [Header("State Objects")] [SerializeField]
    private GameObject pyramid;

    [SerializeField] private GameObject dayNightObject;
    [SerializeField] private GameObject centerLight;
    [SerializeField] private GameObject pressurePlate;
    [SerializeField] private GameObject offboardingText;

    [Header("State Variables")] [SerializeField]
    private int stateAmount = 4;

    [SerializeField] private int currentState = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        SwitchLightState();

        //testing keys
        if (!Input.GetKeyDown("space")) return;
        StartCoroutine(SetLightState());
        Debug.Log("Lighting State" + currentState);
    }

    private void SwitchLightState()
    {
        switch (currentState)
        {
            //DayCycle
            case 0:
                pyramid.SetActive(false);
                dayNightObject.SetActive(true);
                centerLight.SetActive(false);
                break;
            //Dark
            case 1:
                pyramid.SetActive(true);
                dayNightObject.SetActive(false);
                centerLight.SetActive(false);
                //  RenderSettings.skybox.SetFloat("_Exposure", skyboxExposure);
                break;
            //center light
            case 2:
                pyramid.SetActive(true);
                dayNightObject.SetActive(false);
                centerLight.SetActive(true);
                break;
            case 3:
                pressurePlate.SetActive(true);
                offboardingText.SetActive(true);
                break;
        }
    }

    private IEnumerator SetLightState()
    {
        if (currentState < stateAmount)
        {
            currentState++;
        }
        else if (currentState == stateAmount)
        {
            currentState = 0;
        }

        yield return new WaitForEndOfFrame();
    }

    public void SetState()
    {
        StartCoroutine(SetLightState());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SetLightState());
        }
    }
}