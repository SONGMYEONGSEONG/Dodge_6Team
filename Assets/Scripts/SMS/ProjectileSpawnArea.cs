using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileSpawnArea : MonoBehaviour
{

    [SerializeField] private EnumSpawnArea areaPos;
    [SerializeField] private BoxCollider2D collider;
    [SerializeField] private ProjectailSpawnManager projectailSpawnManager;

    Coroutine RandomSpawnCoroutin;
    [SerializeField] private float spawnTime = 1.0f;
    public float SpawnTime { get { return spawnTime; } set { spawnTime = value; } }

    private float halfWidth;
    private float halfHeight;

    private float spawnAreaX;
    private float spawnAreaY;

    [SerializeField] private Transform playerTr;

    private void Awake()
    {
        if (collider == null)
        {
            collider = GetComponent<BoxCollider2D>();
        }
        if(projectailSpawnManager == null)
        {
            Debug.Log("projectailSpawnManager 컴포넌트 호출 실패");
        }

        UI_StartBtn.OnEventGameStart += GameStart;
    }

    //Up Aread에서만 랜덤생성 -Test
    private void Start()
    {
        halfWidth = collider.size.x * 0.5f;
        halfHeight = collider.size.y * 0.5f;
    }

    private void GameStart()
    {
        if (RandomSpawnCoroutin == null)
        {
            RandomSpawnCoroutin = StartCoroutine(RandomSpawn(0));
        }
    }

    //AreaIndex 수정해야됨 
    IEnumerator RandomSpawn(int areaIndex)
    {
        while (true)
        {
            switch (areaPos)
            {
                case EnumSpawnArea.UP:
                    spawnAreaX = UnityEngine.Random.Range(-halfWidth, +halfWidth);
                    spawnAreaY = (float)EnumSpawnAreaLimit.UPDownLimit;
                    break;
                case EnumSpawnArea.DOWN:
                    spawnAreaX = UnityEngine.Random.Range(-halfWidth, +halfWidth);
                    spawnAreaY = (float)EnumSpawnAreaLimit.UPDownLimit * -1;
                    break;
                case EnumSpawnArea.Left:
                    spawnAreaX = (float)EnumSpawnAreaLimit.LeftRightLimit * -1;
                    spawnAreaY = UnityEngine.Random.Range(-halfHeight, +halfHeight);
                    break;
                case EnumSpawnArea.Right:
                    spawnAreaX = (float)EnumSpawnAreaLimit.LeftRightLimit;
                    spawnAreaY = UnityEngine.Random.Range(-halfHeight, +halfHeight);
                    break;
            }

            Vector2 pos = new Vector2(spawnAreaX, spawnAreaY);

            //오브젝트 이름 문자열에 투사체오브젝트 넣어도 됨
            //오브젝트 이름은 지금 테스트 용으로 들어간상태
            //테스트 코드
            Bullet obj = projectailSpawnManager.PoolObject("EnemyBulletSmall", pos);
            int spawnRandNum = UnityEngine.Random.Range(0, 100);
            if (spawnRandNum > 89) //10% 확률
            {
                obj = projectailSpawnManager.PoolObject("EnemyBulletBig", pos);
            }
            else if(spawnRandNum > 69) //30% 확률
            {
                obj = projectailSpawnManager.PoolObject("EnemyBulletMeddle", pos);
            }
            else
            {
                obj = projectailSpawnManager.PoolObject("EnemyBulletSmall", pos);
            }




            Vector2 dir = (playerTr.position - obj.transform.position).normalized;
            obj.OnMove(dir);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
