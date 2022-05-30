using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnboardingBoard : MonoBehaviour
{
    //Needle
    public AudioSource needleAudio;
    public AudioClip needleSFX;
    public GameObject needle1;
    public GameObject needle2;


    //Knitting Board
    public GameObject board;
    //public AudioSource knittingAudio;
    //public AudioClip knitting;
    //public bool keepPlaying = true;
    //public float knitSoundTimer;


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
    }
}
