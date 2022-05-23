using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncy : MonoBehaviour
{
    public float speed;
    public float distance;
    ///public float smooth = 5.0f;
    public float tiltAngle = 360.0f;
    private float originalY;
    public float rotationvalue = 5.0f;
    private Quaternion qTo;
    private float timer = 0.0f;
    public bool manual = false;
    //manual is de knop die hem omzet van automatic rotation naar input horizontal/vertical

    void Start()
    {
        originalY = this.transform.position.y;
    }

    void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1) * distance + originalY;
        this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);

        if (manual)
        {

            float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
            float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

            Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5);

        }
        else
        {
            timer += Time.deltaTime;

            if (timer > 2.0f)
            {
                qTo = Quaternion.Euler(new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f)));
                timer = 0.0f;
            };

            transform.rotation = Quaternion.Slerp(transform.rotation, qTo, Time.deltaTime * 1);
        }
    }
}