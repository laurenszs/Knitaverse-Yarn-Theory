using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParaCube : MonoBehaviour
{
    public int band;
    public float startScale, scaleMult;
    public bool useBuffer;
    Image Colorimage;
    public Material material;

    public int colorMult = 10;

    public Light litty;



    // Update is called once per frame
    void Update()
    {
        Color stuff = new Color32(
            (byte) ((AudioSomething.bandBuffer[band] * scaleMult) * colorMult),
            0, 0, 255);
        litty.intensity =
            (AudioSomething.bandBuffer[band] * scaleMult) * colorMult;

        Debug.Log("Litty" + litty.intensity);
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x,
                (AudioSomething.bandBuffer[band] * scaleMult) + startScale, transform.localScale.z);

            material.SetColor("_Color", stuff);
        }

        if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x,
                (AudioSomething.FreqBand[band] * scaleMult) + startScale, transform.localScale.z);
        }
    }
}
