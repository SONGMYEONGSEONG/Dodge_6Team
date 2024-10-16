using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileSpawnArea : MonoBehaviour
{
    [SerializeField] List<BoxCollider2D> colliders;
    [SerializeField] private ProjectailSpawnManager projectailSpawnManager;


    //Up Aread에서만 랜덤생성 -Test
    private void Update()
    {
        float halfWidth = colliders[0].size.x * 0.5f;
        float hlafHeight = colliders[0].size.y * 0.5f;

        float x = Random.Range(-halfWidth, +halfWidth);
        float y = 7.0f;

        Vector2 pos = new Vector2(x, y);

        projectailSpawnManager.PoolObject("ChildProjectile1", pos);
    }
}
