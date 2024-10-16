using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushEnemyController : EnemyController
{
    [SerializeField] private EnemySO EnemySO;
    private void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove(findPlayer, EnemySO.Speed);
    }
}
