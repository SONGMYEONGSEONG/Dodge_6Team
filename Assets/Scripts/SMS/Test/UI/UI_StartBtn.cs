using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StartBtn : MonoBehaviour
{
    public static event Action OnEventGameStart;
    [SerializeField] private GameObject player_2P;
    public void GameStart()
    {
        GameManager.Instance.Initialize();
        GameManager.Instance.IsPlaying = true;
        OnEventGameStart?.Invoke();

        gameObject.SetActive(false);
    }

    public void GameStart2Player()
    {
        player_2P.SetActive(true);
        GameStart();
        GameManager.Instance.CurPlayerLife += 3;

    }

}
