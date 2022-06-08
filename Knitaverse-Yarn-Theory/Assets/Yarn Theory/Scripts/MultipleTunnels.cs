using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTunnels : MonoBehaviour
{
    public GameObject[] knittingTunnels;
    [SerializeField] private float timeInterval;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("if");
            for (int i = 0; i < knittingTunnels.Length; i++)
            {
                Debug.Log("Coroutine");
                StartCoroutine(ContinuousTunnels((i + 1) * timeInterval, i));
            }
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("if");
            for (int i = 0; i < knittingTunnels.Length; i++)
            {
                Debug.Log("Coroutine");
                StartCoroutine(ContinuousTunnels((i + 1) * timeInterval, i));
            }
        }
    }
    public IEnumerator ContinuousTunnels(float seconds, int index)
    {
        Debug.Log("Ienummerator");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Wait");
        knittingTunnels[index].SetActive(true);

    }
}


