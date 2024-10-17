using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TestMonster : MonoBehaviour, iPoolable<TestMonster>
{
    public event Action<TestMonster> OnEventPushObject;

    [Header("몬스터에 대한 정보")] // 나중에 스크립타블오브젝트로 구현할것 
    public string monsterName = "ChildMonster";
    public int Score= 1000;

    [Header("오브젝트 풀링 생성 갯수")]
    public int PoolCount = 20;

    protected void CompletePurPose()
    {
        OnEventPushObject?.Invoke(this);
    }
}
