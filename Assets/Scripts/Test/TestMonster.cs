using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TestMonster : MonoBehaviour
{
    public event Action<TestMonster> OnEventPushObject;

    public string monsterName = "ChildMonster";
    public int PoolCount = 20;

    protected void CompletePurPose()
    {
        OnEventPushObject?.Invoke(this);
    }
}
