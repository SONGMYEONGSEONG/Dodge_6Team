using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_RetryBtn : MonoBehaviour
{   
    public void RetryBtn()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Sfx.Select);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
