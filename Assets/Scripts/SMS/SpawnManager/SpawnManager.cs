using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnManager<T> : MonoBehaviour, iManager where T : MonoBehaviour
{
    //부모 클래스를 저장
    [SerializeField] protected List<T> prefabesList;

    protected Dictionary<string, ObjectPool<T>> objectPools = new Dictionary<string, ObjectPool<T>>();
    public virtual void Initialize() { }
}
