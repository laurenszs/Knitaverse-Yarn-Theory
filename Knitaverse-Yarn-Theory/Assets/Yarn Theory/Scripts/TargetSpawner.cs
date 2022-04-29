using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab;

    [Header("Spawn Parameters")] public Transform leftBoundary;

    public Transform rightBoundary;

    [SerializeField] private Vector2 spawnInterval;

    [SerializeField] private int maxSpawns;
    [SerializeField] private float SpawnHeightStart;
    private bool spawnable = true;

    [Header("Target Parameters")]
    [SerializeField] private Vector2 targetScaleParameters;

    public List<GameObject> targetList;


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(leftBoundary.position, rightBoundary.position);
    }

    // Update is called once per frame
    private void Update()
    {
        if (targetList.Count < maxSpawns && spawnable)
        {
            StartCoroutine(SpawnTarget());
        }
    }

    private IEnumerator SpawnTarget()
    {
        spawnable = false;
        var xPos = Random.Range(leftBoundary.position.x, rightBoundary.position.x);
        var zPos = Random.Range(leftBoundary.position.z, rightBoundary.position.z);
        var randomScale = Random.Range(targetScaleParameters.x, targetScaleParameters.y);
        var randomRotation = Random.Range(0, 360);

        var newTarget = Instantiate(targetPrefab, gameObject.transform);
        newTarget.transform.position = new Vector3(xPos, SpawnHeightStart, zPos);
        newTarget.transform.localScale = new Vector3(newTarget.transform.localScale.x * randomScale,
            newTarget.transform.localScale.y * randomScale, newTarget.transform.localScale.z * randomScale);
        newTarget.transform.Rotate(new Vector3(randomRotation, randomRotation, randomRotation));
        targetList.Add(newTarget);

        yield return new WaitForSeconds(Random.Range(spawnInterval.x, spawnInterval.y));
        spawnable = true;
    }
}