using Unity.Mathematics;
using UnityEngine;


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
        FadeObject();
      //  CorrectDistances();
    }

    private void FadeObject()
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
    [ExecuteInEditMode]
    private void CorrectDistances()
    {
        if (meshFadeDistance >= billboardFadeDistance)
        {
            billboardFadeDistance -= 1f;
        }
        else if (billboardFadeDistance <= meshFadeDistance)
        {
            meshFadeDistance += 1;
        }
    }
}