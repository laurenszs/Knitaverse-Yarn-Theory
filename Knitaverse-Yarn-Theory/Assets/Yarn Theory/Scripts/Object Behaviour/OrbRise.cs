using System.Collections.Generic;
using UnityEngine;

public class OrbRise : MonoBehaviour
{
    [SerializeField] private GameObject orbContainer;
    [SerializeField] private List<RiseUp> orblist;
    [SerializeField] private GameObject spawners;


    private void Start()
    {
        foreach (var orb in orbContainer.GetComponentsInChildren<RiseUp>())
        {
            orblist.Add(orb);
        }
    }

    private void Update()
    {
        if (LightFade.Instance.fadeCompletion <= 0)
        {
            spawners.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("beep boop collision");
        if (!other.CompareTag("Player")) return;
        Debug.Log(other + " colliding");
        spawners.SetActive(true);
        foreach (var t in orblist)
        {
            Debug.Log(t + " moving up");
            t.MoveUp();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        foreach (var t in orblist)
        {
            t.MoveDown();
        }
    }
}