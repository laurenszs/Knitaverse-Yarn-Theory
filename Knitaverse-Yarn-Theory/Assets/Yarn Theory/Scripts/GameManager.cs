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
    }

    private void Update()
    {
        PlusOne();
    }

    void PlusOne()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0) && cp)
        {
            StartCoroutine(SetPlayerToChecpoint());
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            cp = true;
        }
    }

    IEnumerator SetPlayerToChecpoint()
    {
        _player = GameObject.Find("Player");
        _player.transform.position = urchinCheckpoint.transform.position;
        yield return new WaitForEndOfFrame();
        cp = false;
        yield return new WaitForEndOfFrame();
    }
}