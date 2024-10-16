using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timetxt;
    float time = 0.0f;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timetxt.text = time.ToString("N2");
    }
}
