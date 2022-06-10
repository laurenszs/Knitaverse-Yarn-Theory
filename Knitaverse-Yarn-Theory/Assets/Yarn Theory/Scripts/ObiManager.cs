using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObiManager : MonoBehaviour
{
   [SerializeField] private GameObject player;
   [SerializeField] private GameObject checkPoint;
    private void Start()
    {
        DontDestroyOnLoad(this);
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }
    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name ?? "Replaced";

        if (next == SceneManager.GetSceneByBuildIndex(0))
        {
            checkPoint.SetActive(true);
            player.transform.position = checkPoint.transform.position;
        }
        else
        {
            checkPoint.SetActive(false);
        }
        Debug.Log("Scenes: " + currentName + ", " + next.name);
    }
}
