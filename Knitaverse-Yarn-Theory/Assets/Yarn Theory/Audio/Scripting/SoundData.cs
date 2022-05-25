using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Sound/SoundData")]
public class SoundData : ScriptableObject
{
    [SerializeField]
    private Sounds _name;
    [SerializeField]
    private AudioClip _audio;
    public AudioClip Audio => _audio;
    public Sounds Name => _name;
}
