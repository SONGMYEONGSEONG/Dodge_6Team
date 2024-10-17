using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawnManager : SpawnManager<TestMonster>
{
    //부모 클래스를 저장
    //[SerializeField] List<TestMonster> prefabesList;

    //Dictionary<string, ObjectPool<TestMonster>> objectPools = new Dictionary<string, ObjectPool<TestMonster>>();

    public override void Initialize()
    {
        Debug.Log(gameObject.name + "Initalize 완료!");
    }

    private void Awake()
    {
        TestMonster gameObj;

        foreach (TestMonster prefab in prefabesList)
        {
            GameObject poolContainer = new GameObject("Pool_Container_" + prefab.name);

            ObjectPool<TestMonster> objectPool = new ObjectPool<TestMonster>();

            for (int i = 0; i < prefab.PoolCount; i++)
            {
                gameObj = Instantiate(prefab, poolContainer.transform);
                gameObj.OnEventPushObject += PushObject;
                objectPool.InitPushObject(gameObj);
            }

            objectPools.Add(prefab.monsterName, objectPool);
        }

        Initialize();
    }

    private void PushObject(TestMonster testmonster)
    {
        objectPools[testmonster.monsterName].PushObject(testmonster);
    }


    //float SummonTime = 1.0f;
    //float sum1 = 0.0f;
    //float sum2 = 0.0f;
    //private void Update()
    //{

    //    if (sum1 >= SummonTime)
    //    {
    //        objectPools[prefabesList[0].name].PoolObject(Vector2.zero);
    //        sum1 = 0;
    //    }
    //    else
    //    {
    //        sum1 += Time.deltaTime;
    //    }

    //    if (sum2 >= SummonTime)
    //    {
    //        objectPools[prefabesList[1].name].PoolObject(Vector2.zero);
    //        sum2 = 0;
    //    }
    //    else
    //    {
    //        sum2 += Time.deltaTime;
    //    }
    //}
}
