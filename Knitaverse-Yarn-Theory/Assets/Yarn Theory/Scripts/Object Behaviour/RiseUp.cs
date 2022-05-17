using System.Collections;
using UnityEngine;

public class RiseUp : MonoBehaviour
{
    [SerializeField] private Vector3 movementParams;
    [SerializeField] private float movementSpeed = 1f;
    private Vector3 startPos;
    private Vector3 endPos;

    private void Start()
    {
        endPos = transform.localPosition + movementParams;
        startPos = transform.localPosition;
    }

    private IEnumerator RaiseObject(float duration, Vector3 start, Vector3 end)
    {
        var timer = 0f;

        while (timer < duration)
        {
            var factor = timer / duration;

            transform.localPosition = Vector3.Lerp(start, end, factor);

            timer += Mathf.Min(Time.deltaTime, duration - timer);
            yield return null;
        }

        transform.localPosition = end;
    }

    public void MoveUp()
    {
        StartCoroutine(RaiseObject(movementSpeed, startPos, endPos));
    }

    public void MoveDown()
    {
        StartCoroutine(RaiseObject(movementSpeed, endPos, startPos));
    }
}