using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StartBtn : MonoBehaviour
{
    public static event Action OnEventGameStart;
    [SerializeField] private GameObject[] disableObjects;
    [SerializeField] private GameObject player2P;
    public void GameStart()
    {
        GameManager.Instance.Initialize();
        GameManager.Instance.IsPlaying = true;
        OnEventGameStart?.Invoke();

        foreach (GameObject disableObject in disableObjects)
        {
            disableObject.gameObject.SetActive(false);
        }
    }

    public void GameStart2Player()
    {
        player2P.SetActive(true);
        GameStart();
        GameManager.Instance.CurPlayerLife += 3;

    }

}
