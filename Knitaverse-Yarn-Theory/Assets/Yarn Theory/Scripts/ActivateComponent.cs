using UnityEngine;

public class ActivateComponent : MonoBehaviour
{

    public GameObject[] activateObject;
    public GameObject[] disableObject;
    public GameObject[] stayActiveObject;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < activateObject.Length; i++)
            {
                activateObject[i].gameObject.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < disableObject.Length; i++)
            {
                disableObject[i].gameObject.SetActive(false);
            }
        }
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < stayActiveObject.Length; i++)
            {
                stayActiveObject[i].gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < activateObject.Length; i++)
            {
                activateObject[i].gameObject.SetActive(false);
            }
        }
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < disableObject.Length; i++)
            {
                disableObject[i].gameObject.SetActive(true);
            }
        }

    }

}