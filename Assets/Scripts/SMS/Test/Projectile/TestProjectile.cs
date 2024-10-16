using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour, iPoolable<TestProjectile>
{
    public event Action<TestProjectile> OnEventPushObject;

    [Header("����ü�� ���� ����")] // ���߿� ��ũ��Ÿ�������Ʈ�� �����Ұ� 
    public string projectileName = "ChildProjectile";
    public int Score = 10;

    [Header("������Ʈ Ǯ�� ���� ����")]
    public int PoolCount = 100;

    protected void CompletePurPose()
    {
        OnEventPushObject?.Invoke(this);
    }
}
