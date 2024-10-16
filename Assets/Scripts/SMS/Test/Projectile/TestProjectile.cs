using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour, iPoolable<TestProjectile>
{
    public event Action<TestProjectile> OnEventPushObject;

    [Header("투사체에 대한 정보")] // 나중에 스크립타블오브젝트로 구현할것 
    public string projectileName = "ChildProjectile";
    public int Score = 10;

    [Header("오브젝트 풀링 생성 갯수")]
    public int PoolCount = 100;

    protected void CompletePurPose()
    {
        OnEventPushObject?.Invoke(this);
    }
}
