using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StartBtn : MonoBehaviour
{
    public static event Action OnEventGameStart;
    public void GameStart()
    {
        GameManager.Instance.Initialize();
        GameManager.Instance.IsPlaying = true;
        OnEventGameStart?.Invoke();

        gameObject.SetActive(false);
    }

}
