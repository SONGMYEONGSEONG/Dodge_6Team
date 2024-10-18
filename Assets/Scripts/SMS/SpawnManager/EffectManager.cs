using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : SpawnManager<EffectController>
{


    public override void Initialize()
    {
        Debug.Log(gameObject.name + "Initalize 완료!");
    }

    private void Awake()
    {
        EffectController gameObj;

        foreach (EffectController prefab in prefabesList)
        {
            GameObject poolContainer = new GameObject("Pool_Container_" + prefab.name);

            ObjectPool<EffectController> objectPool = new ObjectPool<EffectController>();

            for (int i = 0; i < prefab._EffectSO.PoolCount; i++)
            {
                gameObj = Instantiate(prefab, poolContainer.transform);
                gameObj.OnEventPushObject += PushObject;
                objectPool.InitPushObject(gameObj);
            }

            objectPools.Add(prefab._EffectSO.EffectName, objectPool);
        }
        Initialize();
    }



    public EffectController PoolObject(string objName, Vector2 spawnPos)
    {
        return objectPools[objName].PoolObject(spawnPos);
    }

    public EffectController PoolObject(EffectController effect, Vector2 spawnPos)
    {
        return objectPools[effect._EffectSO.EffectName].PoolObject(spawnPos);
    }

    private void PushObject(EffectController effect)
    {
        objectPools[effect._EffectSO.EffectName].PushObject(effect);
    }

}