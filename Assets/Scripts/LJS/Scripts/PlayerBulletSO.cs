using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerBulletSO", menuName = "Bullet/Player/Defult",order = 0 )]
public class PlayerBulletSO : DefaultBulletSO
{
    [Header("PlayerBulletInfo")]
    public int bulletDamage;
}
