using System.Collections;
using UnityEngine;

public class RiseUp : MonoBehaviour
{
    [SerializeField] private Vector3 movementParams;
    [SerializeField] private float movementSpeed = 1f;
    private Vector3 startPos;
    private Vector3 endPos;


    // Start is called before the first frame update

    void Start()
    {
        endPos = transform.localPosition + movementParams;
        startPos = transform.localPosition;
    }

    void Update()
    {
        Debug.Log("pos: " + startPos);
        if (Input.GetKeyDown(KeyCode.P)) StartCoroutine(RaiseObject(movementSpeed, startPos, endPos));
        if (Input.GetKeyDown(KeyCode.R)) StartCoroutine(RaiseObject(movementSpeed, endPos, startPos));
    }

    private void OnTriggerStay(Collider other)
    {
        StartCoroutine(RaiseObject(movementSpeed, startPos, endPos));
    }

    private IEnumerator RaiseObject(float duration, Vector3 start, Vector3 end)
    {
        float timer = 0f;
        float factor;

        while (timer < duration)
        {
            factor = timer / duration;

            transform.localPosition = Vector3.Lerp(start, end, factor);

            timer += Mathf.Min(Time.deltaTime, duration - timer);
            yield return null;
        }

        transform.localPosition = end;
    }
}