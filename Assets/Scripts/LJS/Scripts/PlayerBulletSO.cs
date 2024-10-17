using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerBulletSO", menuName = "Bullet/Player/Defult",order = 0 )]
public class PlayerBulletSO : ScriptableObject
{
    [Header("BulletInfo")]
    public string bulletName;
    public int bulletDamage;
    public int bulletSpeed;
    public Sprite bulletSprite;
}
