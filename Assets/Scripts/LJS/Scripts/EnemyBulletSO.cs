using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBulletSO", menuName = "Bullet/Enemy/Defult", order = 0)]

public class EnemyBulletSO : ScriptableObject
{
    [Header("DefaultBulletInfo")]
    public string bulletName;
    public int bulletSpeed;
    public Sprite bulletSprite;
}
