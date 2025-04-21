using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYER_SOUNDS
{
    HURT,
    DEATH,
    SPAWN,

    //

    COUNT,
}

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Put the list of sounds in the order of the enumeration")]
    private List<AudioClip> _playerSounds;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    public void PlaySound(PLAYER_SOUNDS pLAYER_SOUNDS)
    {
        _audioSource.PlayOneShot(_playerSounds[(int)pLAYER_SOUNDS]);
    }
}
