using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sudoku
{
    public class PlayRandomSound : MonoBehaviour
    {
        private AudioSource audioSource;
        public AudioClip[] clips;
        private AudioClip playClip;

        void Start()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            StartCoroutine("PlaySound");
        }

        IEnumerator PlaySound()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(0.0f, 5));
                if (Random.Range(0.0f, 1.0f) < 0.05f)
                {
                    int index = Random.Range(0, clips.Length);
                    playClip = clips[index];
                    audioSource.clip = playClip;
                    audioSource.pitch = Random.Range(0.95f, 1.08f);
                    audioSource.Play();
                }
            }
        }
    }
}