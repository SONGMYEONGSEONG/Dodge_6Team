using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StartBtn : MonoBehaviour
{
    public void GameStart()
    {
        Debug.Log("���ӽ��� 3����");
        Invoke("GameDealyStart", 3.0f);
    }

    private void GameDealyStart()
    {
        Debug.Log("���ӽ���!!");
        Time.timeScale = 1.0f;
    }
}
