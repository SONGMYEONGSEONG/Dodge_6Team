using System;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownController controller;

    [SerializeField] private Transform projectileSpawnPosition;
    [SerializeField] private ProjectailSpawnManager projectailObjectPool;
    private Vector2 aimDirection = Vector2.right;

    public GameObject bulletPrefab;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();

    }
    private void Start()
    {
        controller.OnAttackEvent += OnShoot;
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 _direction)
    {
        aimDirection = _direction;
    }

    private void OnShoot()
    {
        creatProjectile();

    }

    private void creatProjectile()
    {
        //Instantiate(bulletPrefab, projectileSpawnPosition.position, Quaternion.identity);

        Bullet bullet = projectailObjectPool.PoolObject("PlayerBulletSmall", projectileSpawnPosition.position);

        bullet.OnMove(projectileSpawnPosition.up);
    }
}