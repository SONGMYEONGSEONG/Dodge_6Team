using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

//public class EnemySpawnManager : SpawnManager<TestMonster>
public class ItemSpawnManager : SpawnManager<ItemController>
{
    [SerializeField] private float itemSpawnPercent = 80.0f;

    public override void Initialize()
    {
        Debug.Log(gameObject.name + "Initalize 완료!");
    }

    private void Awake()
    {
        //TestMonster gameObj;
        ItemController gameObj;

        //foreach (TestMonster prefab in prefabesList)
        foreach (ItemController prefab in prefabesList)
        {
            GameObject poolContainer = new GameObject("Pool_Container_" + prefab.name);

            //ObjectPool<TestMonster> objectPool = new ObjectPool<TestMonster>();
            ObjectPool<ItemController> objectPool = new ObjectPool<ItemController>();

            //for (int i = 0; i < prefab.PoolCount; i++)
            for (int i = 0; i < prefab.ItemSO.PoolCount; i++)
            {
                gameObj = Instantiate(prefab, poolContainer.transform);
                gameObj.OnEventPushObject += GameManager.Instance.GetScore;
                gameObj.OnEventPushObject += PushObject;
                objectPool.InitPushObject(gameObj);
            }

            //objectPools.Add(prefab.monsterName, objectPool);
            objectPools.Add(prefab.ItemSO.ItemName, objectPool);
        }

        Initialize();
    }

    public ItemController PoolObject(string objName, Vector2 spawnPos)
    {
        return objectPools[objName].PoolObject(spawnPos);
    }
    public ItemController RandomPoolObject(Vector2 spawnPos)
    {
        System.Random random = new System.Random();
        int itemInsRandom = random.Next(1, 101);
        if (itemInsRandom <= itemSpawnPercent)
        {
            int index = UnityEngine.Random.Range(0, prefabesList.Count);
            string itemName = prefabesList[index].ItemSO.ItemName;
            return objectPools[itemName].PoolObject(spawnPos);
        }

        return null;
    }

    public ItemController PoolObject(ItemController item, Vector2 spawnPos)
    {
        return objectPools[item.ItemSO.ItemName].PoolObject(spawnPos);
    }

    //private void PushObject(TestMonster testmonster)
    private void PushObject(ItemController item)
    {
        //objectPools[testmonster.monsterName].PushObject(testmonster);
        objectPools[item.ItemSO.ItemName].PushObject(item);
    }

}
