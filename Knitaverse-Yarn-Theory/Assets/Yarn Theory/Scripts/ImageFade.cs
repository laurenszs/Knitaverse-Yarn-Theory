using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFade : MonoBehaviour
{
    [SerializeField]  private  List<Image> UIImages;

    public float fadeSpeed = 1;


    IEnumerator FadeIn()
    {
        float alpha = UIImages[0].color.a;

        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            for (int i = 0; i < UIImages.Count; i++)
            {
                UIImages[i].color = new Color(UIImages[i].color.r, UIImages[i].color.g, UIImages[i].color.b, alpha);
            }

            yield return null;

        }


    }
}
