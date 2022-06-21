using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject urchinCheckpoint;
    public bool cp;
    private GameObject _player;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += PlusOne;
        StartCoroutine(ChangeNumbers());
    }

    void PlusOne(Scene scene1, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0) && cp)
        {
            StartCoroutine(SetPlayerToChecpoint());
        }
    }

    IEnumerator SetPlayerToChecpoint()
    {
        _player = GameObject.Find("Player");
        _player.transform.position = urchinCheckpoint.transform.position;
        yield return new WaitForEndOfFrame();
    }

    IEnumerator ChangeNumbers()
    {
        yield return new WaitForSeconds(2);
        cp = true;
        yield return new WaitForEndOfFrame();
    }
}