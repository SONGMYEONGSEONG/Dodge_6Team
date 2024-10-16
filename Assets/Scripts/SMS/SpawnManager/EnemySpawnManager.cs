using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnManager : SpawnManager
{
    //부모 클래스를 저장
    [SerializeField] List<TestMonster> prefabesList;

    Dictionary<string, ObjectPool<TestMonster>> objectPools = new Dictionary<string, ObjectPool<TestMonster>>();

    public override void Initialize()
    {
        Debug.Log(gameObject.name + "Initalize 완료!");
    }

    private void Awake()
    {
        foreach(TestMonster prefab in prefabesList)
        {
            ObjectPool<TestMonster> objectPool = new ObjectPool<TestMonster>();
            objectPool.Initailize(prefab.PoolCount, prefab);

            objectPools.Add(prefab.name,objectPool);
        }
    }

    private void Start()
    {
        Initialize();

    }

    float SummonTime = 1.0f;
    float sum1 = 0.0f;
    float sum2 = 0.0f;
    private void Update()
    {

        if (sum1 >= SummonTime)
        {
            objectPools[prefabesList[0].name].PoolObject();
            sum1 = 0;
        }
        else
        {
            sum1 += Time.deltaTime;
        }

        if (sum2 >= SummonTime)
        {
            objectPools[prefabesList[1].name].PoolObject();
            sum2 = 0;
        }
        else
        {
            sum2 += Time.deltaTime;
        }
    }
}
