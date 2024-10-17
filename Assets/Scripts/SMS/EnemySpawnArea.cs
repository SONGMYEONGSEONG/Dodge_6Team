using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemySpawnArea : MonoBehaviour
{
    static event Action OnEventGameStart;

    [SerializeField] private EnumSpawnArea areaPos;
    [SerializeField] private BoxCollider2D collider;
    [SerializeField] private EnemySpawnManager enemySpawnManager;

    Coroutine RandomSpawnCoroutin;
    [SerializeField] private float spawnTime = 4.0f;
    public float SpawnTime { get { return spawnTime; } set { spawnTime = value; } }

    private float halfWidth;
    private float halfHeight;

    private float spawnAreaX;
    private float spawnAreaY;

    //멀티플레이어를 생각해서 만들어놓은 변수
    [SerializeField] private Transform playersTr;

    private void Awake()
    {
        if (collider == null)
        {
            collider = GetComponent<BoxCollider2D>();
        }
        if(enemySpawnManager == null)
        {
            Debug.Log("enemySpawnManager 컴포넌트 호출 실패");
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
            yield return new WaitForSeconds(spawnTime);

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
            EnemyController obj = enemySpawnManager.PoolObject("RushEnemy", pos);
            //EnemyController obj = enemySpawnManager.PoolObject("ShooterEnemy", pos);
        }
    }
}
