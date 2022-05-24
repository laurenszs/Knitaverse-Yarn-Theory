using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    [SerializeField] private float colorSpeed = .1f;
    [SerializeField] private float colorOffset = .005f;
    public List<Color> lightList;


    // Start is called before the first frame update
    void Start()
    {
        lightList.Add(GetComponentInChildren<Light>().color);
    }

    // Update is called once per frame
    void Update()
    {
        // GetComponentInChildren<Light>().col
    }

    public void RainbowRoad()
    {
        var colorTimer = 0f;

        colorTimer += (colorSpeed * Time.deltaTime);
        if (colorTimer > 1)
        {
            colorTimer = 0;
        }

        float s = 1f, v = 1f;
        for (int i = 0; i < lightList.Count; i++)
        {
            var OS = colorTimer + (i * colorOffset);
            Color.RGBToHSV(lightList[i], out OS, out s, out v);
        }
    }
}