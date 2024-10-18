using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    private AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null )
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }


    public void PlaySound()
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("오디오클립없음");
        }
    }

    public void ContolSound(bool shouldPlay)
    {
        if(!shouldPlay)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}
