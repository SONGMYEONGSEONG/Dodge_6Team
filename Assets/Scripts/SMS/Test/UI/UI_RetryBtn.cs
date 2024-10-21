using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_RetryBtn : MonoBehaviour
{   
    public void RetryBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
