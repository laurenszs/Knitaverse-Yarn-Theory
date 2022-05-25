using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public enum Sounds
{
    Steps,
    grabbing,
    Knitting
}

public class AudioLibrary : MonoBehaviour
{
    public static AudioLibrary instance;
    public AudioSource audioPlayer, musicPlayer;

    [SerializeField] private List<SoundData> _soundFX = new List<SoundData>();

    public static Dictionary<Sounds, AudioClip> audioclips = new Dictionary<Sounds, AudioClip>();

    private static Dictionary<Sounds, float> playingSounds = new Dictionary<Sounds, float>();

    public float tempInterval = -1f;
    
    private float timer;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        StartCoroutine(loopsound(Sounds.Knitting));
    }

    private void Start()
    {
        foreach (SoundData sound in _soundFX)
        {
            audioclips.Add(sound.Name, sound.Audio);
        }

        audioPlayer = GetComponentInChildren<AudioSource>();
    }

    public static void PlaySound(Sounds playSound)
    {
        try
        {
            AudioLibrary.instance.audioPlayer.PlayOneShot(audioclips[playSound]); //plays audio based on given string
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
        }
    }

    /// <summary>If the sound clip is already playing because of this method then this method won't play the sound.</summary>
    public static void PlaySoundOneAtATime(Sounds playSound)
    {
        //Look if it is in the dictionary and if it is done playing then it removes it from the dictionary.
        if (playingSounds.ContainsKey(playSound))
        {
            if (playingSounds[playSound] < Time.timeSinceLevelLoad)
            {
                playingSounds.Remove(playSound);
            }
        }

        //If it is not in the dictionary then it plays the sound and adds it to the dictionary.
        if (!playingSounds.ContainsKey(playSound))
        {
            PlaySound(playSound);
            playingSounds.Add(playSound, Time.timeSinceLevelLoad + audioclips[playSound].length);
        }
    }

    public void PlayRandomSound(params Sounds[] sound)
    {
        PlaySound(sound[UnityEngine.Random.Range(0, sound.Length)]);
    }

    public IEnumerator loopsound(Sounds playsound)
    {
        PlaySound(playsound);

        yield return new WaitForSeconds(audioclips[playsound].length);
    }
}