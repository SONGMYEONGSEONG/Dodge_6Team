using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushEnemyController : EnemyController
{
    /*20241017 - �۸� ��ġ ���� ShooterEnemyController -> EnemyController*/
    //[SerializeField] private EnemySO enemySO;
    private void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove(findPlayer, enemySO.Speed);        
    }
}
