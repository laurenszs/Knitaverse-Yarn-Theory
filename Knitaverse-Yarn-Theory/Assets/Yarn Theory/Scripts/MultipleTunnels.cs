using System.Collections;
using UnityEngine;

public class MultipleTunnels : MonoBehaviour
{
    public GameObject[] knittingTunnels;
    [SerializeField] private float timeInterval;

    private void OnTriggerEnter(Collider other)
    {
        if (knittingTunnels.Length == 0)
        {
            Debug.LogWarning("tunnel list is empty");
        }
        else
        {
            for (int i = 0; i < knittingTunnels.Length; i++)
            {
                StartCoroutine(ContinuousTunnels((i + 1) * timeInterval, i));
            }
        }
    }

    public IEnumerator ContinuousTunnels(float seconds, int index)
    {
        yield return new WaitForSeconds(seconds);
        knittingTunnels[index].SetActive(true);
    }
}