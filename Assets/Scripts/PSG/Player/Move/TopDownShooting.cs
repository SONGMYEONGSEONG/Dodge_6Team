using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class TopDownShooting : MonoBehaviour
{
    private TopDownController controller;
    [SerializeField] private StatHandler statHandler;

    [SerializeField] private Transform projectileSpawnPosition;
    [SerializeField] private Transform playerPivot;
    [SerializeField] private ProjectailSpawnManager projectailObjectPool;
    private Vector2 aimDirection = Vector2.right;

    [SerializeField] private float angle = 30.0f;

   public GameObject bulletPrefab;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        statHandler = GetComponent<StatHandler>();
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
        switch (statHandler.ProjectilePower % 2 == 0)
        {
            case true://짝수
                creatProjectileMulti(statHandler.ProjectilePower, 0.5f);
                break;

            case false://홀수

                Bullet bullet;
                bullet = projectailObjectPool.PoolObject("PlayerBulletSmall", projectileSpawnPosition.position);
                bullet.OnMove(projectileSpawnPosition.up);

                creatProjectileMulti(statHandler.ProjectilePower, 0);
                break;
        }
    }

    private void creatProjectileMulti(int projectilePower, float pos)
    {
        if (projectilePower <= 1) return;

        float leftAngle = -angle / 2;
        float rightAngle = angle / 2;
        float playerRotZ = playerPivot.transform.eulerAngles.z;

        Bullet bullet;
        float roopCount = Mathf.Ceil(projectilePower * 0.5f);
        for (int i = 0; i < roopCount; i++)
        { 
            //왼쪽 방향 총알 로직
            bullet = projectailObjectPool.PoolObject("PlayerBulletSmall", projectileSpawnPosition.position);
            bullet.OnMove(GetProjectileMoveDir(playerRotZ, leftAngle,i));

            //오른쪽 방향 총알 로직
            bullet = projectailObjectPool.PoolObject("PlayerBulletSmall", projectileSpawnPosition.position);
            bullet.OnMove(GetProjectileMoveDir(playerRotZ, rightAngle, i));
        }
    }

    private Vector2 GetProjectileMoveDir(float playerRotZ, float dirAngle,int index)
    {
        float resultAngle = (playerRotZ + (dirAngle * (index + 1)) + 90.0f) * Mathf.Deg2Rad;


        float x = Mathf.Cos(resultAngle);
        float y = Mathf.Sin(resultAngle);

        return new Vector2(x, y).normalized;
    }
}