using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectailSpawnManager : SpawnManager<TestProjectile>
{
    public override void Initialize()
    {
        Debug.Log(gameObject.name + "Initalize 완료!");
    }

    private void Awake()
    {

    }

    private void Start()
    {
        TestProjectile gameObj;

        foreach (TestProjectile prefab in prefabesList)
        {
            GameObject poolContainer = new GameObject("Pool_Container_" + prefab.name);

            ObjectPool<TestProjectile> objectPool = new ObjectPool<TestProjectile>();


            for (int i = 0; i < prefab.PoolCount; i++)
            {
                gameObj = Instantiate(prefab, poolContainer.transform);
                gameObj.OnEventPushObject += PushObject;
                objectPool.InitPushObject(gameObj);
            }

            objectPools.Add(prefab.projectileName, objectPool);
        }

        Initialize();
    }

    private void PushObject(TestProjectile testmonster)
    {
        objectPools[testmonster.projectileName].PushObject(testmonster);
    }


    float SummonTime = 1.0f;
    float sum1 = 0.0f;
    float sum2 = 0.0f;
    private void Update()
    {

        if (sum1 >= SummonTime)
        {
            objectPools[prefabesList[0].name].PoolObject(Vector2.zero);
            sum1 = 0;
        }
        else
        {
            sum1 += Time.deltaTime;
        }

        if (sum2 >= SummonTime)
        {
            objectPools[prefabesList[1].name].PoolObject(Vector2.zero);
            sum2 = 0;
        }
        else
        {
            sum2 += Time.deltaTime;
        }
    }
}