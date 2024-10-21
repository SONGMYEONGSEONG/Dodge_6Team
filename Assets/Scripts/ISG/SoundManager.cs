using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("#BGM")]
    public AudioClip bgmClip;
    public float bgmVolume; 
    AudioSource bgmPlayer;

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex;

    public enum Sfx { Select, Fire, Hit, Item, Gameover ,EnemyDie}

    private void Awake()
    {
        Instance = this;
        Init();
    }

    void Init()
    {
        //����� �÷��̾� �ʱ�ȭ
        GameObject bgmObject = new GameObject("BGMPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;
        //ȿ���� �÷��̾� �ʱ�ȭ
        GameObject sfxObject = new GameObject("SFXPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for(int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].volume = sfxVolume;
        }
        PlayBGM(true);
    }

    public void PlayBGM(bool isPlay)
    {
        if (isPlay)
        {
            bgmPlayer.Play();
        }
        else
        {
            bgmPlayer.Stop();
        }
    }

    public void PlaySFX(Sfx sfx)
    {
        sfxPlayers[(int)sfx].clip = sfxClips[(int)sfx];
        sfxPlayers[(int)sfx].PlayOneShot(sfxPlayers[(int)sfx].clip);
        //    for (int index = 0; index < sfxPlayers.Length; index++)
        //    {
        //        int loopIndex = (index + channelIndex) % sfxPlayers.Length;

        //        if (sfxPlayers[loopIndex].isPlaying)
        //            continue;

        //        int ranIndex = 0;
        //        if (sfx == Sfx.Hit)
        //        {
        //            ranIndex = Random.Range(0, 2);
        //        }
        //        channelIndex = loopIndex;
        //        sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
        //        sfxPlayers[loopIndex].Play();
        //        break;
        //    }
    }

    public void PlayGameOverSound()
    {
        PlaySFX(Sfx.Gameover);
        PlayBGM(false);
    }
}
