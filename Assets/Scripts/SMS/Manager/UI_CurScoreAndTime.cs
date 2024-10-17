using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class UI_CurScoreAndTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTMP;
    [SerializeField] private TextMeshProUGUI timeTMP;

   StringBuilder strBuilder = new StringBuilder();

    public void ScoreDisplay(int score)
    {
        strBuilder.Clear();
        strBuilder.Append(score.ToString());
        scoreTMP.text = strBuilder.ToString();
    }

    public void TimeDisplay(float time)
    {
        strBuilder.Clear();
        strBuilder.Append(time.ToString("N2"));
        timeTMP.text = strBuilder.ToString();
    }
}
