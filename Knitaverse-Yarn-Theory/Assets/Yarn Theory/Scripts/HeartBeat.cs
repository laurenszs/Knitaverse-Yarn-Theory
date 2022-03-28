using Unity.Mathematics;
using UnityEngine;


public class HeartBeat : MonoBehaviour
{
    [SerializeField] private Material _beatMaterial;

    public float beatMin = 0, beatMax = 0.08f;
    [SerializeField] private float beatStage;

    [SerializeField] private float speed;


    private HeartBeat()
    {
        _beatMaterial = GetComponent<Material>();
    }

    void Update()
    {
        PlayHeartBeat();
    }

    private void PlayHeartBeat()
    {
        if (beatStage <= beatMin)
        {
            beatStage = beatMin;
        }

        if (beatStage >= beatMax)
        {
            beatStage = beatMax;
        }

        _beatMaterial.SetFloat("_Parallax", Mathf.Clamp(beatStage, beatMin, beatMax));
    }
}