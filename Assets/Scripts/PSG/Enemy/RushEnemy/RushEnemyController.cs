using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushEnemyController : EnemyController
{
    [SerializeField] private EnemySO enemySO;
    private void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyCheck)
        {
            EnemyMove(findPlayer, enemySO.Speed);
        }
        else
        {
            findPlayer = GameObject.FindGameObjectWithTag("Player").gameObject;
        }
    }
}
