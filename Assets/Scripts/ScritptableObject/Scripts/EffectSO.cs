using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EffectSO", menuName = "Effects/default", order = 0)]
public class EffectSO : ScriptableObject
{
    [Header("ObjectPooling Count")]
    public string EffectName;
    public int PoolCount;
}

