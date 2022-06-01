using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnboardingBoard : MonoBehaviour
{
    //Needle
    public AudioSource needleAudio;
    public AudioClip needleSFX;
    public GameObject needle1;
    public GameObject needle2;


    //Knitting Board
    public GameObject board;

    public List<Image> UIImages = new List<Image>();

    public float fadeSpeed = 1;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExecuteAfterTime());
    }

    IEnumerator ExecuteAfterTime()
    {
        Debug.Log("Pass");
        yield return new WaitForSeconds(1f);
        needleAudio.PlayOneShot(needleSFX);
        needle1.SetActive(true);
        yield return new WaitForSeconds(1f);
        needleAudio.PlayOneShot(needleSFX);
        needle2.SetActive(true);
        yield return new WaitForSeconds(1f);
        board.SetActive(true);
        yield return new WaitForSeconds(2f);

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
