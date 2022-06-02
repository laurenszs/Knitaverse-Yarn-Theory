using UnityEngine;

public class ActivateComponent : MonoBehaviour
{
    [Tooltip("activates object on trigger enter and disables it when leaving the trigger")]
    public GameObject[] activateObject;
    [Tooltip("disables object on trigger enter and activates it when leaving the trigger")]
    public GameObject[] disableObject;
    [Tooltip("activates object on trigger enter")]
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
        StartCoroutine(TunnelNext());
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
        IEnummerator TunnelNext()
    }

}