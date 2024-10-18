using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class ObjectPool<T> where T : MonoBehaviour
{
    public Queue<T> PoolQueue = new Queue<T>();

    public bool InitPushObject(T poolObject)
    {
        if (poolObject == null) 
        {
            Debug.Log(poolObject.name + "�� null �Դϴ�.");
            return false;
        }

        poolObject.gameObject.SetActive(false);
        PoolQueue.Enqueue(poolObject);

        return true;
    }

    public T PoolObject(Vector2 pos)
    {
        if (PoolQueue.Count <= 5)
        {
            Debug.Log(typeof(T).Name + "������Ʈ ���� ����!");

            return null;
        }

        T obj = PoolQueue.Dequeue();
        obj.gameObject.transform.position = pos;
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void PushObject(T pushObj)
    {
        pushObj.gameObject.SetActive(false);
        PoolQueue.Enqueue(pushObj);
        //Debug.Log("�Ѿ� ť ����"+PoolQueue.Count);
    }



}