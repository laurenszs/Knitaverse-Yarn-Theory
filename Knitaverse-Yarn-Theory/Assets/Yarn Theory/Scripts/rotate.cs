using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(30, 0, 0) * Time.deltaTime);
    }
}
