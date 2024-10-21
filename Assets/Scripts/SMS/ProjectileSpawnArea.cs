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
    [SerializeField] private float spawnTimeLimit = 0.1f;
    public float SpawnTime
    {
        get
        {
            return spawnTime;
        }
        set
        {
            if (value <= spawnTimeLimit)
            {
                spawnTime = spawnTimeLimit; 
            }
            else
            {
                spawnTime = value;
            }
        }
    }

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
            Debug.Log("projectailSpawnManager ÄÄÆ÷³ÍÆ® È£Ãâ ½ÇÆÐ");
        }

        UI_StartBtn.OnEventGameStart += GameStart;
        GameManager.Instance.OnEventGameOver += GameOver;
    }
    private void OnDestroy()
    {
        UI_StartBtn.OnEventGameStart -= GameStart;
        GameManager.Instance.OnEventGameOver -= GameOver;
    }

    //Up Aread¿¡¼­¸¸ ·£´ý»ý¼º -Test
    private void Start()
    {
        halfWidth = collider.size.x * 0.5f;
        halfHeight = collider.size.y * 0.5f;
    }
    public void GameOver()
    {
        gameObject.SetActive(false);
    }
    private void GameStart()
    {
        if (RandomSpawnCoroutin == null)
        {
            RandomSpawnCoroutin = StartCoroutine(RandomSpawn(0));
        }
    }

    //AreaIndex ¼öÁ¤ÇØ¾ßµÊ 
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

            Bullet obj;
            int spawnRandNum = UnityEngine.Random.Range(0, 100);
            if (spawnRandNum > 89) //10% È®·ü
            {
                obj = projectailSpawnManager.PoolObject("EnemyBulletBig", pos);
            }
            else if(spawnRandNum > 69) //30% È®·ü
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
