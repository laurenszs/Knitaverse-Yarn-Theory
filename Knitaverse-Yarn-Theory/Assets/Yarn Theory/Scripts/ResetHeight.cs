using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHeight : MonoBehaviour
{
  //  [SerializeField] private float resetHeight;

    void Update()
    {
        //if (transform.localPosition.y < resetHeight) transform.localPosition = new Vector3(transform.localPosition.x, resetHeight, transform.localPosition.z);

        if (transform.parent.tag != "Hands") GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
}
