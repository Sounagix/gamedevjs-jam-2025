using System;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYER_SOUNDS
{
    HURT,
    DEATH,
    SPAWN,
    RUN,
    JUMP,
    CHARGE,
    SHOT,
    ERROR,
    POSITIVE,
    NEGATIVE,
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


    public void PlayOnShot(PLAYER_SOUNDS pLAYER_SOUNDS)
    {
        _audioSource.PlayOneShot(_playerSounds[(int)pLAYER_SOUNDS]);
    }

    public bool IsPlaying(PLAYER_SOUNDS pLAYER_SOUNDS)
    {
        return _audioSource.clip == _playerSounds[(int)pLAYER_SOUNDS] && _audioSource.isPlaying;
    }

    public void Play(PLAYER_SOUNDS pLAYER_SOUNDS, bool loop = false)
    {
        _audioSource.clip = _playerSounds[(int)pLAYER_SOUNDS];
        _audioSource.loop = loop;
        _audioSource.Play();
    }

    public void StopSounds(PLAYER_SOUNDS pLAYER_SOUNDS)
    {
        if (IsPlaying(pLAYER_SOUNDS))
            _audioSource.Stop();
    }
}
