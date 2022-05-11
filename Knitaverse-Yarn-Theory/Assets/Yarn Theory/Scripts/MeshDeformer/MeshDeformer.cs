using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformer : MonoBehaviour
{
     Mesh deformingMesh;
    Vector3[] originalVertices, displacedVertices;
    Vector3[] vertexVelocities;

    void Start()
        //Copy the orignal vertices to the displaced vertices
    {
        deformingMesh = GetComponent<MeshFilter>().mesh;
        originalVertices = deformingMesh.vertices;
        displacedVertices = new Vector3[originalVertices.Length];
        for (int i = 0; i<originalVertices.Length; i++)
        { displacedVertices[i] = originalVertices[i]; }
        //store the velocity of each vertex
        vertexVelocities = new Vector3[originalVertices.Length];
    }

    void Update()
    {
        
    }
    public void AddDeformingForce(Vector3 point, float force)
    {
        Debug.DrawRay(new Vector3 (0,0,0),new Vector3(0,5,0));
    }
    public void OnDrawGizmos()
    {
        //Gizmos.DrawLine(Camera.main.transform.position, point);
    }
}
