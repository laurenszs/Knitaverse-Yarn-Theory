using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioSomething : MonoBehaviour
{
    private AudioSource _audiosource;
    public static readonly float[] samples = new float[512];
    public FFTWindow windowFFt;
    public static readonly float[] FreqBand = new float[8];
    public static readonly float[] bandBuffer = new float[8];
    private readonly float[] _bufferDecrease = new float[8];
    public float higher = 0.005f, lower = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        _audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        BandBuffer();
        Makefreqbands();
        if (higher <= 0f)
        {
            higher = 0f;
        }
        if (lower <= 0f)
        {
            lower = 0f;
        }
    }

    private void GetSpectrumAudioSource()
    {
        _audiosource.GetSpectrumData(samples, 0, windowFFt);
    }

    private void BandBuffer()
    {
        for (int g = 0; g < 8; g++)
        {
            if (FreqBand[g] > bandBuffer[g])
            {
                bandBuffer[g] = FreqBand[g];
                _bufferDecrease[g] = higher;
            }
            if (FreqBand[g] < bandBuffer[g])
            {
                bandBuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= lower;
            }
        }
    }

    private void Makefreqbands()
    {
        /*44100 / 512(sampleCount) = 192
         * 
         * 
         * 0 - 2
         * 1 - 4
         * 2 - 8
         * 3 - 16
         * 4 - 32
         * 5 - 64
         * 6 - 128
         * 7 - 256
         */

        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }
            average /= count;
            FreqBand[i] = average;
        }
    }

}
