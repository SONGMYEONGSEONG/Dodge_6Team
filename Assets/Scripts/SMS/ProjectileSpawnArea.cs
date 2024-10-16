using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileSpawnArea : MonoBehaviour
{
    [SerializeField] List<BoxCollider2D> colliders;
    [SerializeField] private ProjectailSpawnManager projectailSpawnManager;

    Coroutine RandomSpawnCoroutin;
    [SerializeField] private float spawnTime =1.0f;

    //공격로직에서 총알 방향값 줄수있게 수정해야됨
    [SerializeField] private Transform TestplayerTr;

    //Up Aread에서만 랜덤생성 -Test
    private void Start()
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
            float halfWidth = colliders[areaIndex].size.x * 0.5f;
            float halfHeight = colliders[areaIndex].size.y * 0.5f;

            float x = Random.Range(-halfWidth, +halfWidth);
            float y = 7.0f;

            Vector2 pos = new Vector2(x, y);

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
