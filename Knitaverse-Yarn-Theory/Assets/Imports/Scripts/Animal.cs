using System.Collections;
using UnityEngine;

namespace Sudoku
{
    public class Animal : MonoBehaviour
    {
        [HideInInspector]
        public AnimalController controller;
        public Vector3 wayPoint;
        public float speed;
        public float damping;
        public float targetSpeed;
        Animator anim;

        public void Start()
        {
            RandomSize();
            anim = transform.GetComponent<Animator>();
            wayPoint = findWaypoint();
            damping = Random.Range(controller.minTurning, controller.maxTurning);
            targetSpeed = Random.Range(controller.minSpeed, controller.maxSpeed);
            anim.speed = anim.speed * controller.animSpeedModifier;
        }

        public void Update()
        {
            Movement();
        }

        public void RandomSize()
        {
            float randomNum = Random.Range(0.6f, 1.2f);
            Vector3 randomSize = new Vector3(randomNum, randomNum, randomNum);
            transform.localScale = randomSize;
        }

        public void Movement()
        {
            Vector3 lookAt = wayPoint - transform.position;
            if (targetSpeed > -1 && lookAt != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(lookAt);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, controller.newDelta * damping);
            }

            if ((transform.position - controller.posBuffer).magnitude < 1)
            {
                controller.SetFlockRandomPosition();
            }

            speed = Mathf.Lerp(speed, targetSpeed, controller.newDelta * 2.5f);
            transform.position += transform.forward * speed * controller.newDelta;

            if ((transform.position - wayPoint).magnitude < controller.waypointDistance)
            {
                StartCoroutine("Wander", 0f);
            }
        }

        IEnumerator Wander(float delay)
        {
            yield return new WaitForSeconds(delay);
            wayPoint = findWaypoint();
            StartCoroutine("SpeedAnimTurning");
        }

        IEnumerator SpeedAnimTurning()
        {
            anim.speed = controller.animSpeedWhileTurning * controller.animSpeedModifier;
            targetSpeed *= controller.speedBoostWhileTurning;
            yield return new WaitForSeconds(1.5f);
            anim.speed = Random.Range(0.8f, 1.1f) * controller.animSpeedModifier; ;
            targetSpeed = Random.Range(controller.minSpeed, controller.maxSpeed);
        }

        public Vector3 findWaypoint()
        {
            Vector3 t = Vector3.zero;
            t.x = Random.Range(-controller.wayPointBoxWidth, controller.wayPointBoxWidth) + controller.posBuffer.x;
            t.z = Random.Range(-controller.wayPointBoxDepth, controller.wayPointBoxDepth) + controller.posBuffer.z;
            t.y = Random.Range(-controller.wayPointBoxHeight, controller.wayPointBoxHeight) + controller.posBuffer.y;
            return t;
        }
    }
}
