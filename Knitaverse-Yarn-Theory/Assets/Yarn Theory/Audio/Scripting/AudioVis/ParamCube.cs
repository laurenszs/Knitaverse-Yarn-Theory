using UnityEngine;
using Image = UnityEngine.UI.Image;

public class ParamCube : MonoBehaviour
{
    [Range(0, 8)] public int band;
    public float startScale, scaleMult;
    public bool useMovement;
    public Material material;

    public int colorMult = 10;


    // Update is called once per frame
    void Update()
    {
        Color stuff = new Color32(
            (byte) ((AudioSomething.bandBuffer[band] * scaleMult) * colorMult),
            0, 0, 255);

        if (useMovement)
        {
            transform.localScale = new Vector3((AudioSomething.bandBuffer[band] * scaleMult) + startScale,
                (AudioSomething.bandBuffer[band] * scaleMult) + startScale,
                (AudioSomething.bandBuffer[band] * scaleMult) + startScale);

            material.SetColor("_EmissionColor", stuff);
        }

        if (!useMovement)
        {
            material.SetColor("_EmissionColor", stuff);
        }
    }
}