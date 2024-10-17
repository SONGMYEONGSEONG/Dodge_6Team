using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class UI_CurScoreAndTimeAndLife : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTMP;
    [SerializeField] private TextMeshProUGUI timeTMP;
    [SerializeField] private TextMeshProUGUI lifeTMP;

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

    public void LifeDisplay(int life)
    {
        if(life < 0)
        {
            life = 0;
        }

        strBuilder.Clear();
        strBuilder.Append(life.ToString());
        lifeTMP.text = strBuilder.ToString();
    }
}
