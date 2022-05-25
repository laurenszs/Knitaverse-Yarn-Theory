using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Obi;

[RequireComponent(typeof(ObiCollider))]
public class RopeGrabber : MonoBehaviour
{
    public bool canGrab = true;
    ObiSolver solver;
    ObiCollider obiCollider;
    public ObiSoftbody rope;
    ObiSolver.ObiCollisionEventArgs collisionEvent;
    ObiPinConstraintsBatch newBatch;
    ObiConstraints<ObiPinConstraintsBatch> pinConstraints;

    void Awake()
    {
        // solver = FindObjectOfType<ObiSolver>();
        obiCollider = GetComponent<ObiCollider>();
    }
    void Start()
    {
        // get a hold of the constraint type we want, in this case, pin constraints:
        solver = rope.solver;
        pinConstraints = rope.GetConstraintsByType(Oni.ConstraintType.Pin) as ObiConstraints<ObiPinConstraintsBatch>;
    }

    private void OnEnable()
    {
        if (solver != null)
            solver.OnCollision += Solver_OnCollision;
    }

    private void OnDisable()
    {
        if (solver != null)
            solver.OnCollision -= Solver_OnCollision;
    }

    private void Solver_OnCollision(object sender, Obi.ObiSolver.ObiCollisionEventArgs e)
    {
        collisionEvent = e;
    }

    public void Grab()
    {
        var world = ObiColliderWorld.GetInstance();
        Debug.Log(pinConstraints);

        if (solver != null && collisionEvent != null)
        {
            Debug.Log("Collision");
            foreach (Oni.Contact contact in collisionEvent.contacts)
            {
                if (contact.distance < 0.01f)
                {
                    var contactCollider = world.colliderHandles[contact.bodyB].owner;
                    ObiSolver.ParticleInActor pa = solver.particleToActor[contact.bodyB];

                    Debug.Log(pa + " hit " + contactCollider);
                    if (canGrab)
                    {
                        if (contactCollider == obiCollider)
                        {
                            Debug.Log("Hand Collision");
                            var batch = new ObiPinConstraintsBatch();
                            int solverIndex = contact.bodyB;
                            Vector3 positionWS = solver.transform.TransformPoint(solver.positions[solverIndex]); // particle position from solver to world space
                            Vector3 positionCS = obiCollider.transform.InverseTransformPoint(positionWS); // particle position from world to collider space
                            batch.AddConstraint(rope.solverIndices[contact.bodyB], obiCollider, positionCS, Quaternion.identity, 0, 0, float.PositiveInfinity);
                            batch.activeConstraintCount = 1;
                            newBatch = batch;
                            pinConstraints.AddBatch(newBatch);

                            canGrab = false;

                            // this will cause the solver to rebuild pin constraints at the beginning of the next frame:
                            rope.SetConstraintsDirty(Oni.ConstraintType.Pin);

                        }
                    }
                }
            }
        }
    }

    public void Release()
    {
        if (!canGrab)
        {
            Debug.Log("Release");
            pinConstraints.RemoveBatch(newBatch);
            rope.SetConstraintsDirty(Oni.ConstraintType.Pin);
            canGrab = true;
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) Grab();
        if (Input.GetKeyDown(KeyCode.R)) Release();
    }
}