﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

//public class EnemySpawnManager : SpawnManager<TestMonster>
public class EnemySpawnManager : SpawnManager<EnemyController>
{
    [SerializeField] private ItemSpawnManager itemSpawnManager;
    [SerializeField] private EffectManager effectManager;
    public override void Initialize()
    {
        Debug.Log(gameObject.name + "Initalize 완료!");
    }

    private void Awake()
    {
        //TestMonster gameObj;
        EnemyController gameObj;

        //foreach (TestMonster prefab in prefabesList)
        foreach (EnemyController prefab in prefabesList)
        {
            GameObject poolContainer = new GameObject("Pool_Container_" + prefab.name);

            //ObjectPool<TestMonster> objectPool = new ObjectPool<TestMonster>();
            ObjectPool<EnemyController> objectPool = new ObjectPool<EnemyController>();

            //for (int i = 0; i < prefab.PoolCount; i++)
            for (int i = 0; i < prefab.EnemySO.PoolCount; i++)
            {
                gameObj = Instantiate(prefab, poolContainer.transform);
                //gameObj.OnEventPushObject += GameManager.Instance.GetScore;
                gameObj.OnEventDieObject += GameManager.Instance.GetScore;
                gameObj.OnEventPushObject += PushObject;
                gameObj.OnEventDropItem += itemSpawnManager.RandomPoolObject;
                gameObj.OnEventDieEffectObject += effectManager.PoolObject;
                objectPool.InitPushObject(gameObj);
            }

            //objectPools.Add(prefab.monsterName, objectPool);
            objectPools.Add(prefab.EnemySO.enemyName, objectPool);
        }

        Initialize();
    }

    public EnemyController PoolObject(string objName, Vector2 spawnPos)
    {
        return objectPools[objName].PoolObject(spawnPos);
    }

    public EnemyController PoolObject(EnemyController enemy, Vector2 spawnPos)
    {
        return objectPools[enemy.EnemySO.enemyName].PoolObject(spawnPos);
    }

    //private void PushObject(TestMonster testmonster)
    private void PushObject(EnemyController enemy)
    {
        //objectPools[testmonster.monsterName].PushObject(testmonster);
        objectPools[enemy.EnemySO.enemyName].PushObject(enemy);
    }

}
