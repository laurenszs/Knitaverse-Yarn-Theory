using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformerInput : MonoBehaviour
{
    public float force = 10f;
    public float forceOffset = 0.1f;

    void Start()
    {

    }

    void Update()
    {
        //User's input by pressing down the mouse button (click or drag)
        if (Input.GetMouseButton(0))
        {
            HandleInput();
        }
    }
    //Pointing of the user to the object
    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //Physics engine to cast the ray
        if (Physics.Raycast(inputRay, out hit))
        {
            //Add a deforming force at the contact point
            MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();
            if (deformer)
            {
                Vector3 point = hit.point;
                point += hit.normal * forceOffset;
                deformer.AddDeformingForce(point, force);
            }
        }
    }

}
