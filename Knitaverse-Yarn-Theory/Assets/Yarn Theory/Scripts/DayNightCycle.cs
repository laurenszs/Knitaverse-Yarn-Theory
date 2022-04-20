using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Range(0.0f, 1.0f)] public float time;
    [SerializeField] private float fullDayLength;
    [SerializeField] private float startTime = .4f;
    private float timeRate;
    [SerializeField] private Vector3 noon;

    [Header("Sun")] [SerializeField] private Light sun;
    [SerializeField] private Gradient sunColor;
    [SerializeField] private AnimationCurve sunIntensity;

    [Header("Moon")] [SerializeField] private Light moon;
    [SerializeField] private Gradient moonColor;
    [SerializeField] private AnimationCurve moonIntensity;

    [Header("Other Lighting")] [SerializeField]
    private AnimationCurve lightingIntesityMultiplier;

    [SerializeField] private AnimationCurve reflectionsIntensityMultiplier;
    private Material skyboxMaterial;

    private void Start()
    {
        timeRate = 1f / fullDayLength;
        time = startTime;

        skyboxMaterial = RenderSettings.skybox;
    }

    // Update is called once per frame
    public void Update()
    {
        time += timeRate * Time.deltaTime;

        if (time >= 1f)
        {
            time = 0f;
        }

        SetCelestialProperties();
        EnableCelestial();
    }

    private void SetCelestialProperties()
    {
        //set rotation
        sun.transform.eulerAngles = (time - .25f) * noon * 4f;
        moon.transform.eulerAngles = (time - .75f) * noon * 4f;
        //light intensity
        sun.intensity = sunIntensity.Evaluate(time);
        moon.intensity = moonIntensity.Evaluate(time);
        //set light colors
        sun.color = sunColor.Evaluate(time);
        moon.color = moonColor.Evaluate(time);
        //set skybox color
        /*SetSkyboxExposure(3.5f);
        if (sun.gameObject.activeInHierarchy)
        {
            skyboxMaterial.SetColor("_GroundColor", sun.color);
            skyboxMaterial.SetColor("_SkyTint", sun.color);
        }
        else
        {
            skyboxMaterial.SetColor("_GroundColor", moon.color);
            skyboxMaterial.SetColor("_SkyTint", moon.color);
        }*/
    }

    public void SetSkyboxExposure(float exposure)
    {
        skyboxMaterial.SetFloat("_Exposure", exposure);
    }

    private void EnableCelestial()
    {
        switch (sun.intensity)
        {
            case 0 when sun.gameObject.activeInHierarchy:
                sun.gameObject.SetActive(false);
                break;
            case > 0 when !moon.gameObject.activeInHierarchy:
                sun.gameObject.SetActive(true);
                break;
        }

        switch (moon.intensity)
        {
            case 0 when sun.gameObject.activeInHierarchy:
                moon.gameObject.SetActive(false);
                break;
            case > 0 when !moon.gameObject.activeInHierarchy:
                moon.gameObject.SetActive(true);
                break;
        }
    }

    private void AmbientProperties()
    {
        RenderSettings.ambientIntensity = lightingIntesityMultiplier.Evaluate(time);
        RenderSettings.reflectionIntensity = reflectionsIntensityMultiplier.Evaluate(time);
    }
}