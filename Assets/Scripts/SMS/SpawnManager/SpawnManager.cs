using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnManager<T> : MonoBehaviour, iManager where T : MonoBehaviour
{
    //�θ� Ŭ������ ����
    [SerializeField] protected List<T> prefabesList;

    protected Dictionary<string, ObjectPool<T>> objectPools = new Dictionary<string, ObjectPool<T>>();
    public virtual void Initialize() { }
}
