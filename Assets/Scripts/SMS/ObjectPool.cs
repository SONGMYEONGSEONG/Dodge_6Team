using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPool<T> : MonoBehaviour where T : Component
{
    public Queue<T> PoolQueue = new Queue<T>();

    public void Initailize(int poolCount, T poolObject)
    {
        GameObject poolContainer = new GameObject("Pool_Container_" + poolObject.name);
        
        T gameObj;
        for (int i = 0; i < poolCount; i++)
            {
                gameObj = Instantiate(poolObject, poolContainer.transform);
                gameObj.gameObject.SetActive(false);
                PoolQueue.Enqueue(gameObj);
            }
    }

    public T PoolObject()
    {
        if(PoolQueue.Count <= 0)
        {
            Debug.Log(typeof(T).Name + "오브젝트 갯수 부족!");
            return null;
        }

        T obj = PoolQueue.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }


}