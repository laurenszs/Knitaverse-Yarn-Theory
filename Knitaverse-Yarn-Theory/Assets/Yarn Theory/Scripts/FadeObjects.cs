using System;
using Unity.Mathematics;
using UnityEngine;

public class FadeObjects : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float fadingDistance = 10f;

    [SerializeField] private string materialProperty;
    private Material _fadingMaterial;
    private float _collisionPoint;
    private bool _triggered;

    private void Start()
    {
        _collisionPoint = transform.lossyScale.x / 2;
        _fadingMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        var actualDistance =
            math.distance(math.distance(transform.position, player.transform.position), _collisionPoint);

        if (actualDistance <= fadingDistance)
        {
            _fadingMaterial.SetFloat(materialProperty, actualDistance / fadingDistance);
        }
        else
        {
            _fadingMaterial.SetFloat(materialProperty, 1);
        }

        if (materialProperty == String.Empty)
        {
            Debug.LogWarning("No property added to fading script");
        }
    }

    private void OnDrawGizmos()
    {
        if (!(math.distance(math.distance(transform.position, player.transform.position),
                _collisionPoint) <= fadingDistance)) return;
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, player.transform.position);
    }
}