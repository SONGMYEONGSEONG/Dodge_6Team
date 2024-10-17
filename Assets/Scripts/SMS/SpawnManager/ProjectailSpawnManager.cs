using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectailSpawnManager : SpawnManager<Bullet>
{
    public override void Initialize()
    {
        Debug.Log(gameObject.name + "Initalize 완료!");
    }

    private void Awake()
    {
        Bullet gameObj;

        foreach (Bullet prefab in prefabesList)
        {
            GameObject poolContainer = new GameObject("Pool_Container_" + prefab.name);

            ObjectPool<Bullet> objectPool = new ObjectPool<Bullet>();


            for (int i = 0; i < prefab.defaultBulletSO.PoolCount; i++)
            {
                gameObj = Instantiate(prefab, poolContainer.transform);
                gameObj.OnEventPushObject += PushObject;
                objectPool.InitPushObject(gameObj);
            }

            objectPools.Add(prefab.defaultBulletSO.bulletName, objectPool);
        }

        Initialize();
    }


    public Bullet PoolObject(string objName , Vector2 spawnPos)
    {
        return objectPools[objName].PoolObject(spawnPos);
    }

    public Bullet PoolObject(Bullet testProjectile, Vector2 spawnPos)
    {

        return objectPools[testProjectile.defaultBulletSO.bulletName].PoolObject(spawnPos);
    }

    private void PushObject(Bullet testProjectile)
    {
        objectPools[testProjectile.defaultBulletSO.bulletName].PushObject(testProjectile);
    }

    /* Test :: 총알 랜덤 생성 지역 */



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