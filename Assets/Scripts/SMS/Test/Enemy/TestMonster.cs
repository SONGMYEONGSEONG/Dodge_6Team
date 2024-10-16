using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TestMonster : MonoBehaviour, iPoolable<TestMonster>
{
    public event Action<TestMonster> OnEventPushObject;

    [Header("���Ϳ� ���� ����")] // ���߿� ��ũ��Ÿ�������Ʈ�� �����Ұ� 
    public string monsterName = "ChildMonster";
    public int Score= 1000;

    [Header("������Ʈ Ǯ�� ���� ����")]
    public int PoolCount = 20;

    protected void CompletePurPose()
    {
        OnEventPushObject?.Invoke(this);
    }
}
