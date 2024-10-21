using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultulletSO", menuName = "Bullet/Defult", order = 0)]

public class DefaultBulletSO : ScriptableObject
{
    [Header("DefaultBulletInfo")]
    public string bulletName;
    public int bulletSpeed;
    public Sprite bulletSprite;

    [Header("ObjectPoolCount")]
    public int PoolCount;
}
