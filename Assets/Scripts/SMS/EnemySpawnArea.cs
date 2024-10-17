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

    //��Ƽ�÷��̾ �����ؼ� �������� ����
    [SerializeField] private Transform playersTr;

    private void Awake()
    {
        if (collider == null)
        {
            collider = GetComponent<BoxCollider2D>();
        }
        if(enemySpawnManager == null)
        {
            Debug.Log("enemySpawnManager ������Ʈ ȣ�� ����");
        }

        UI_StartBtn.OnEventGameStart += GameStart;
    }

    //Up Aread������ �������� -Test
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
    //AreaIndex �����ؾߵ� 
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

            //������Ʈ �̸� ���ڿ��� ����ü������Ʈ �־ ��
            //������Ʈ �̸��� ���� �׽�Ʈ ������ ������
            EnemyController obj = enemySpawnManager.PoolObject("RushEnemy", pos);
            //EnemyController obj = enemySpawnManager.PoolObject("ShooterEnemy", pos);
        }
    }
}
