using System.Collections.Generic;
using UnityEngine;

public enum ECHO_SOUNDS
{
    HURT,
    DEATH,
    SPAWN,

    //

    COUNT,
}

public class EchoSounds : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Put the list of sounds in the order of the enumeration")]
    private List<AudioClip> _echoSounds;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    public void PlaySound(ECHO_SOUNDS eCHO_SOUNDS)
    {
        _audioSource.PlayOneShot(_echoSounds[(int)eCHO_SOUNDS]);
    }
}
