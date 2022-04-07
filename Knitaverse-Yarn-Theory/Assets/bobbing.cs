using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class bobbing : MonoBehaviour
{
    public float speed;
    private float originalY;
    public float distance;

    void Start()
    {
        originalY = this.transform.position.y;
    }

    void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1) * distance + originalY;
        this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
    }
}