using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_RetryBtn : MonoBehaviour
{
    [SerializeField] private string sceneName;
    
    public void RetryBtn()
    {
        SceneManager.LoadScene(sceneName);
    }

}
