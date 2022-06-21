using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject urchinCheckpoint;
    public int sceneChanges;
    private GameObject _player;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
        SceneManager.activeSceneChanged += PlusOne;
    }

    void PlusOne(Scene scene1, Scene scene2)
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0) && sceneChanges >= 1)
        {
            StartCoroutine(Stuff());
        }
    }

    IEnumerator Stuff()
    {
        sceneChanges++;
        _player = GameObject.Find("Player");
        _player.transform.position = urchinCheckpoint.transform.position;
        yield return new WaitForEndOfFrame();
    }
}