using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StartBtn : MonoBehaviour
{
    public static event Action OnEventGameStart;
    [SerializeField] private GameObject player2P;
    [SerializeField] private Button[] buttons;
    public void GameStart()
    {
        GameManager.Instance.Initialize();
        GameManager.Instance.IsPlaying = true;
        OnEventGameStart?.Invoke();

       foreach(Button button in buttons) 
        { 
            button.gameObject.SetActive(false);
        }
    }

    public void GameStart2Player()
    {
        player2P.SetActive(true);
        GameStart();
        GameManager.Instance.CurPlayerLife += 3;

    }

}
