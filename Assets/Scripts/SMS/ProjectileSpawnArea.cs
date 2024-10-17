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

    //공격로직에서 총알 방향값 줄수있게 수정해야됨
    [SerializeField] private Transform TestplayerTr;

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
    }

    //Up Aread에서만 랜덤생성 -Test
    private void Start()
    {
        if (RandomSpawnCoroutin == null)
        {
            RandomSpawnCoroutin = StartCoroutine(RandomSpawn(0));
        }

        halfWidth = collider.size.x * 0.5f;
        halfHeight = collider.size.y * 0.5f;
    }

    //AreaIndex 수정해야됨 
    IEnumerator RandomSpawn(int areaIndex)
    {
        while (true)
        {
            switch (areaPos)
            {
                case EnumSpawnArea.UP:
                    spawnAreaX = Random.Range(-halfWidth, +halfWidth);
                    spawnAreaY = 6.0f;
                    break;
                case EnumSpawnArea.DOWN:
                    spawnAreaX = Random.Range(-halfWidth, +halfWidth);
                    spawnAreaY = -6.0f;
                    break;
                case EnumSpawnArea.Left:
                    spawnAreaX = -10.0f;
                    spawnAreaY = Random.Range(-halfHeight, +halfHeight);
                    break;
                case EnumSpawnArea.Right:
                    spawnAreaX = 10.0f;
                    spawnAreaY = Random.Range(-halfHeight, +halfHeight);
                    break;
            }


            Vector2 pos = new Vector2(spawnAreaX, spawnAreaY);

            //오브젝트 이름 문자열에 투사체오브젝트 넣어도 됨
            //오브젝트 이름은 지금 테스트 용으로 들어간상태
            //테스트 코드
            TestProjectile obj = projectailSpawnManager.PoolObject("ChildProjectile1", pos);
            if (obj != null)
            {
                Vector2 dir = (TestplayerTr.position - obj.transform.position).normalized;
                obj.GetComponent<Rigidbody2D>().velocity = dir * 3.0f;
            }

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
