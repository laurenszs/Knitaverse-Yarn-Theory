using UnityEngine;
using System.Collections.Generic;

namespace Sudoku
{
    public class AnimalController : MonoBehaviour
    {

        public Animal childPrefab;
        public int childAmount;
        public float minSpeed;
        public float maxSpeed;
        public float minTurning;
        public float maxTurning;
        public float waypointDistance;
        public float randomPositionTimer;
        public float wayPointBoxWidth;
        public float wayPointBoxHeight;
        public float wayPointBoxDepth;
        public float roamBoxWidth;
        public float roamBoxHeight;
        public float roamBoxDepth;
        public float forcedRandomDelay;
        public bool forceNewWaypoints;
        public float animSpeedWhileTurning;
        public float speedBoostWhileTurning;
        public float animSpeedModifier;
        [HideInInspector]
        public List<Animal> roamers;
        [HideInInspector]
        public Vector3 posBuffer;
        [HideInInspector]
        public float newDelta;

        public void Start()
        {
            posBuffer = transform.position;
            AddChild(childAmount);
            if (randomPositionTimer > 0) InvokeRepeating("SetFlockRandomPosition", randomPositionTimer, randomPositionTimer);
        }

        public void AddChild(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Animal obj = (Animal)Instantiate(childPrefab, GenerateRandomPosition(), Random.rotation, transform);
                obj.controller = this;
                roamers.Add(obj);
            }
        }

        public void Update()
        {
            newDelta = Time.deltaTime;
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(posBuffer, new Vector3(wayPointBoxWidth * 2, wayPointBoxHeight * 2, wayPointBoxDepth * 2));
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, new Vector3(roamBoxWidth * 2, roamBoxHeight * 2, roamBoxDepth * 2));
        }

        //Set waypoint randomly inside box
        public void SetFlockRandomPosition()
        {
            posBuffer = GenerateRandomPosition();
            if (forceNewWaypoints)
            {
                for (int i = 0; i < roamers.Count; i++)
                {
                    roamers[i].StartCoroutine("Wander", Random.value * forcedRandomDelay);
                }
            }
        }

        public Vector3 GenerateRandomPosition()
        {
            Vector3 t = Vector3.zero;
            t.x = Random.Range(-roamBoxWidth, roamBoxWidth) + transform.position.x;
            t.z = Random.Range(-roamBoxDepth, roamBoxDepth) + transform.position.z;
            t.y = Random.Range(-roamBoxHeight, roamBoxHeight) + transform.position.y;
            return t;
        }
    }
}

