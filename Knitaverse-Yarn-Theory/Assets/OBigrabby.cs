using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

[RequireComponent(typeof(ObiSolver))]
public class OBigrabby : MonoBehaviour
{

	ObiSolver solver;

	void Awake()
	{
		solver = GetComponent<ObiSolver>();
	}

	void OnEnable()
	{
		solver.OnCollision += Solver_OnCollision;
	}

	void OnDisable()
	{
		solver.OnCollision -= Solver_OnCollision;
	}

	void Solver_OnCollision(object sender, Obi.ObiSolver.ObiCollisionEventArgs e)
	{
		var world = ObiColliderWorld.GetInstance();
		// just iterate over all contacts in the current frame:
		foreach (Oni.Contact contact in e.contacts)
		{
// Debug.Log(contact.pointA + contact.pointB);
			// if this one is an actual collision:
			if (contact.distance < 0.01) //& Vector4.Distance(contact.pointA, contact.pointB) < 1) 
			{
				ObiColliderBase col = world.colliderHandles[contact.bodyB].owner;
				if (col != null)
				{
					ObiActor a = solver.particleToActor[contact.bodyA].actor;
					ObiActor b = solver.particleToActor[contact.bodyB].actor;
					// do something with the collider.
					if (solver.actors.Contains(a) && solver.actors.Contains(b) && a!=b){
						Debug.Log("Contact between two softbodies"+ contact.distance+ solver.particleToActor[contact.bodyA].actor + solver.particleToActor[contact.bodyB].actor);
						break;
					}
//					Debug.Log(solver.particleToActor[contact.bodyA].actor);
//					Debug.Log(solver.particleToActor[contact.bodyB].actor);
				}
			}
		}
	}

}