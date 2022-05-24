using UnityEngine;

public class Floating : MonoBehaviour
{
    [Range(0, 1f)] [SerializeField] private float speed;
    [Range(0, 2f)] [SerializeField] private float length;
    private float originalY;

    void Start()
    {
        originalY = this.transform.position.y;
    }

    void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, length) * 0.1f + originalY;
        transform.position = new Vector3(this.transform.position.x, y, transform.position.z);
    }
}