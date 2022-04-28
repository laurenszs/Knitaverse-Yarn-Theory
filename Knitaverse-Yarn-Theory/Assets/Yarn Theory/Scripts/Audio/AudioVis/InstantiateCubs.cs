using UnityEngine;

public class InstantiateCubs : MonoBehaviour
{
    public GameObject cubePrefab;
    private readonly GameObject[] _cubeArray = new GameObject[AudioSomething.samples.Length];
    public float maxScale;
    public Vector3 wavelength = new(10, 2, 10);
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _cubeArray.Length; i++)
        {
            GameObject instanceCube = Instantiate(cubePrefab, transform, true);
            instanceCube.transform.position = transform.position;
            instanceCube.name = "cube Instance" + i;
            transform.eulerAngles = new Vector3(0, -(360 / (float)_cubeArray.Length) * i, 0);
            instanceCube.transform.position = Vector3.forward * 100;
            _cubeArray[i] = instanceCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _cubeArray.Length; i++)
        {
            if (_cubeArray != null)
            {
                _cubeArray[i].transform.localScale = wavelength + new Vector3(0, AudioSomething.samples[i] * maxScale, 0);
            }
        }
    }
}
