using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformerInput : MonoBehaviour
{
    public float force = 10f;

    void Start()
    {

    }

    void Update()
    {
        //user's input by pressing down the mouse button (click or drag)
        if (Input.GetMouseButton(0))
        {
            HandleInput();
        }
    }
    //pointing of the user to the object
    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //physics engine to cast the ray
        if (Physics.Raycast(inputRay, out hit))
        {
            //add a deforming force at the contact point
            MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();
            if (deformer)
            {
                Vector3 point = hit.point;
                deformer.AddDeformingForce(point, force);
            }
        }
    }

}
