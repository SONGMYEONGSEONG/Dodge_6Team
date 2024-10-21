using System;
using System.Collections;
using UnityEngine;

public class ShooterEnemyController : EnemyController
{
    private ProjectailSpawnManager projectailObjectPool;
    private Coroutine ShootDelayCoroutine;
    private float shootAngle = 45.0f;

    /*20241017 - 송명성 위치 변경 ShooterEnemyController -> EnemyController*/
    //[SerializeField] private EnemySO enemySO;
    private void Start()
    {
        base.Start();
        if(projectailObjectPool == null)
        {
            projectailObjectPool = GameManager.Instance.ProjectailObjectPool;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove(findPlayer, enemySO.Speed);

        //적과 내 거리가 설정한 변수보다 작을때
        if (Vector2.Distance(findPlayer.transform.position, transform.position) <= enemySO.TargetDist)
        {
            if (ShootDelayCoroutine == null)
            {
                ShootDelayCoroutine = StartCoroutine(EnemyShootDelay());
            }
        }
        else
        {
            if (ShootDelayCoroutine != null)
            {
                StopCoroutine(ShootDelayCoroutine);
                ShootDelayCoroutine = null;
            }
        }
    }

    private void EnemyShooting(Vector2 direction)
    {

        for (int i = -enemySO.ShootCount / 2; i <= enemySO.ShootCount / 2; i++)
        {
            float angle = shootAngle * i / enemySO.ShootCount; // 각도 계산
            Vector2 bulletDir = Quaternion.Euler(0, 0, angle) * direction; // 방향 계산


            Bullet bullet;
            bullet = projectailObjectPool.PoolObject("EnemyBulletBig", transform.position);
            bullet.OnMove(bulletDir);
        }

       


    }

    IEnumerator EnemyShootDelay()
    {
        while (true)
        {
            Vector2 dir = (findPlayer.transform.position - transform.position).normalized;
            EnemyShooting(dir);
            yield return new WaitForSeconds(enemySO.ShootDelay);
        }
    }
}
