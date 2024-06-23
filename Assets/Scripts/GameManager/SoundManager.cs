using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource soundSource;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void PlaySound(AudioClip sound)
    {
        soundSource.PlayOneShot(sound);
    }
}
