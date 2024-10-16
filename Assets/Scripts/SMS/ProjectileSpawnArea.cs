using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileSpawnArea : MonoBehaviour
{
    [SerializeField] List<BoxCollider2D> colliders;
    [SerializeField] private ProjectailSpawnManager projectailSpawnManager;

    Coroutine RandomSpawnCoroutin;
    [SerializeField] private float spawnTime =1.0f;

    //���ݷ������� �Ѿ� ���Ⱚ �ټ��ְ� �����ؾߵ�
    [SerializeField] private Transform TestplayerTr;

    //Up Aread������ �������� -Test
    private void Start()
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
            float halfWidth = colliders[areaIndex].size.x * 0.5f;
            float halfHeight = colliders[areaIndex].size.y * 0.5f;

            float x = Random.Range(-halfWidth, +halfWidth);
            float y = 7.0f;

            Vector2 pos = new Vector2(x, y);

            //������Ʈ �̸� ���ڿ��� ����ü������Ʈ �־ ��
            //������Ʈ �̸��� ���� �׽�Ʈ ������ ������
            //�׽�Ʈ �ڵ�
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
