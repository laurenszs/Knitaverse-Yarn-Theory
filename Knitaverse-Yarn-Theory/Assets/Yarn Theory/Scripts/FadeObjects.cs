using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FadeObjects : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float fadingDistance = 10f;

    private float _collisionPoint;
    [SerializeField] private Material fadingMaterial;
    private bool _triggered;
    private static readonly int Opacity = Shader.PropertyToID("_Opacity");

    private void Start()
    {
        _collisionPoint = transform.localScale.x / 2;
    }

    private void Update()
    {
        var actualDistance =
            math.distance(_collisionPoint, math.distance(transform.position, player.transform.position));

        if (actualDistance <= fadingDistance)
        {
            fadingMaterial.SetFloat(Opacity, actualDistance / fadingDistance);
        }
        else
        {
            fadingMaterial.SetFloat(Opacity, 1);
        }
        
        //Debug.Log(actualDistance);
    }
}