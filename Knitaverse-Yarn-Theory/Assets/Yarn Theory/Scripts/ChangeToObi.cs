using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToObi : MonoBehaviour
{
    public GameObject player;
    private void Awake()
    {
        DontDestroyOnLoad(player);
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(1);
    }
}
