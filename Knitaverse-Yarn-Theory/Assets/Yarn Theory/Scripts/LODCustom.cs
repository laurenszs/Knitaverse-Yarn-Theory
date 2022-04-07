using System.Collections;
using Unity.Mathematics;
using UnityEngine;

[ExecuteInEditMode]
public class LODCustom : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [Header("Objects")] [SerializeField] private GameObject meshObject;
    [SerializeField] private GameObject billboardObject;

    [Header("View distance")] [SerializeField]
    private float meshFadeDistance;

    [SerializeField] private float billboardFadeDistance;

    private void Update()
    {
        SwitchObject();
        CheckValues();
    }

    private void SwitchObject()
    {
        var viewDistance = math.distance(transform.position, playerCamera.transform.position);

        if ((viewDistance <= meshFadeDistance))
        {
            meshObject.SetActive(true);
            billboardObject.SetActive(false);
        }
        else if ((viewDistance >= meshFadeDistance) && (viewDistance <= billboardFadeDistance))
        {
            meshObject.SetActive(false);
            billboardObject.SetActive(true);
        }
        else if ((viewDistance >= billboardFadeDistance))
        {
            meshObject.SetActive(false);
            billboardObject.SetActive(false);
        }
    }

    private void CheckValues()
    {
        if (meshFadeDistance >= billboardFadeDistance)
        {
            StartCoroutine(CorrectDistances());
        }
    }

    private IEnumerator CorrectDistances()
    {
        meshFadeDistance = billboardFadeDistance - .1f;
        StopCoroutine(CorrectDistances());
        yield return new WaitForEndOfFrame();
    }
}