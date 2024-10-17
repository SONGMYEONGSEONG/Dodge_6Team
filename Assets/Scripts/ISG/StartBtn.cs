using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBtn : MonoBehaviour
{
    public Button startButton;
    public event Action OnStartClicked;

    private void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
    }
    
    private void OnStartButtonClick()
    {
        OnStartClicked?.Invoke();
    }

    public void HideButton()
    {
        gameObject.SetActive(false);
    }
}
