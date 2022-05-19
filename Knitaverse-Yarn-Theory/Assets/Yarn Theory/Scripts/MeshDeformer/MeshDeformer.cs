using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformer : MonoBehaviour
{
    Mesh deformingMesh;
    Vector3[] originalVertices, displacedVertices;
    Vector3[] vertexVelocities;
    public float springForce = 20f;
    public float damping = 5f;
    float uniformScale = 1f;

    void Start()
    //Copy the orignal vertices to the displaced vertices
    {
        deformingMesh = GetComponent<MeshFilter>().mesh;
        originalVertices = deformingMesh.vertices;
        displacedVertices = new Vector3[originalVertices.Length];
        for (int i = 0; i < originalVertices.Length; i++)
        { displacedVertices[i] = originalVertices[i]; }
        //Store the velocity of each vertex
        vertexVelocities = new Vector3[originalVertices.Length];
    }
    public void AdjustScale()
    {
        //The deformation has to be the same no matter the scale
        uniformScale = transform.localScale.x;
    }
    void Update()
    {
        AdjustScale();
        for (int i = 0; i < displacedVertices.Length; i++)
        {
            UpdateVertex(i);
        }
       //Assign the displaced vertices
        deformingMesh.vertices = displacedVertices;
        deformingMesh.RecalculateNormals();
    }
    public void AddDeformingForce(Vector3 point, float force)
    {
        //Perform the deformation on the side of the camera angle if the mesh is rotated
        point = transform.InverseTransformPoint(point);
              for (int i = 0; i < displacedVertices.Length; i++)
        {
            AddForceToVertex(i, point, force);
        }
    }
    void AddForceToVertex (int i, Vector3 point, float force)
    {
        //Determine the force of the deformation point
        Vector3 pointToVertex = displacedVertices[i] - point;
        pointToVertex *= uniformScale;
        float attenuatedForce = force / (1f + pointToVertex.sqrMagnitude);
        //Determine the velocity of the deformation point
        float velocity = attenuatedForce * Time.deltaTime;
        vertexVelocities[i] += pointToVertex.normalized * velocity;
        
    }
    void UpdateVertex (int i)
    {
        Vector3 velocity = vertexVelocities[i];
        //Add a springforce so that the deformation will bounce back
        Vector3 displacement = displacedVertices[i] - originalVertices[i];
        displacement *= uniformScale;
        velocity -= displacement * springForce * Time.deltaTime;
        velocity *= 1f - damping * Time.deltaTime;
        vertexVelocities[i] = velocity;
        displacedVertices[i] += velocity * (Time.deltaTime / uniformScale);
    }
}
