using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseUp : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    private Vector3 startPos;
    private Vector3 endPos = new Vector3(0, 0, 1);

    private float platformRaiseDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        StartCoroutine(RaiseObject(platformRaiseDuration));
    }

    private IEnumerator RaiseObject(float duration)
    {
        float timer = 0f;
        float factor;

        while (timer < duration)
        {
            factor = timer / duration;

            targetObject.transform.localPosition = Vector3.Lerp(startPos, endPos, factor);

            timer += Mathf.Min(Time.deltaTime, duration - timer);
            yield return null;
        }

        targetObject.transform.localPosition = endPos;
    }
}