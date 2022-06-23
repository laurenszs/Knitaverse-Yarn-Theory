using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FadePoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float fadingDistance = 10f;

    [SerializeField] private string materialProperty;
    [SerializeField] private GameObject fadeObject;
    private Material _fadingMaterial;
    private float _collisionPoint;
    public float fadeOffset = .3f;

    private void Start()
    {
        _collisionPoint = transform.lossyScale.x / 2;
        _fadingMaterial = fadeObject.GetComponent<Renderer>().material;
    }

    private void Update()
    {
        var actualDistance =
            math.distance(player.transform.position, transform.position);

        if (actualDistance <= fadingDistance /*&& ((actualDistance / fadingDistance) - fadeOffset) >= 0*/)
        {
            _fadingMaterial.SetFloat(materialProperty, (actualDistance / fadingDistance) - fadeOffset);
        }
        else if (actualDistance > fadingDistance)
        {
            _fadingMaterial.SetFloat(materialProperty, 1);
        }
    }
}
