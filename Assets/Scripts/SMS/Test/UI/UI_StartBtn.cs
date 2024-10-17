using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StartBtn : MonoBehaviour
{
    public void GameStart()
    {
        Debug.Log("게임시작 3초전");
        Invoke("GameDealyStart", 3.0f);
    }

    private void GameDealyStart()
    {
        Debug.Log("게임시작!!");
        Time.timeScale = 1.0f;
    }
}
