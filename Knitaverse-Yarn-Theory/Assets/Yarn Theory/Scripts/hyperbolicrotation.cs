using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hyperbolicrotation : MonoBehaviour
{
    public Vector3 rotationSpeed;
    void Update()
    {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }
}
