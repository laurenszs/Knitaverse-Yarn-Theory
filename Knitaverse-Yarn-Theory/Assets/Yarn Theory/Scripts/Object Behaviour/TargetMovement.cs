using UnityEngine;
using Random = UnityEngine.Random;

public class TargetMovement : MonoBehaviour
{
    public float scrollSpeed;
    [SerializeField] private float maxHeight = 25;
    public float respawnHeight = 0;
    private Vector3 spawnRight, spawnLeft;

    private void Start()
    {
        var parent = gameObject.transform.parent;
        spawnLeft = parent.GetComponentInParent<TargetSpawner>().leftBoundary;
        spawnRight = parent.GetComponentInParent<TargetSpawner>().rightBoundary;
    }

    private void Update()
    {
        ScrollTarget();
        RespawnTarget();
    }

    private void ScrollTarget()
    {
        var position = transform.localPosition;
        transform.localPosition = new Vector3(position.x, position.y + scrollSpeed, position.z);
    }

    private void RespawnTarget()
    {
        var xPos = Random.Range(spawnLeft.x, spawnRight.x);
        var zPos = Random.Range(spawnLeft.z, spawnRight.z);
        if (transform.localPosition.y >= maxHeight) transform.localPosition = new Vector3(xPos, respawnHeight, zPos);
    }
}