using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour
{
    public GameObject[] bulletPrefabs; // 여러 총알 프리팹 배열
    public int poolSize = 10;
    // 각 프리팹마다 개별 풀을 관리하기 위한 리스트
    private List<Queue<GameObject>> bulletPools;

    void Start()
    {
        bulletPools = new List<Queue<GameObject>>();

        // 각 프리팹에 대해 풀을 생성
        for (int i = 0; i < bulletPrefabs.Length; i++)
        {
            Queue<GameObject> bulletPool = new Queue<GameObject>();

            for (int j = 0; j < poolSize; j++)
            {
                GameObject bullet = Instantiate(bulletPrefabs[i]);
                bullet.SetActive(false);
                bulletPool.Enqueue(bullet);
            }

            bulletPools.Add(bulletPool);
        }
    }

    // 특정 유형의 총알을 풀에서 꺼내는 함수
    public GameObject GetBullet(Vector3 position, Quaternion rotation, int bulletTypeIndex)
    {
        if (bulletTypeIndex >= 0 && bulletTypeIndex < bulletPools.Count && bulletPools[bulletTypeIndex].Count > 0)
        {
            GameObject bullet = bulletPools[bulletTypeIndex].Dequeue();
            bullet.SetActive(true);
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;

            return bullet;
        }
        else
        {
            Debug.Log("풀에 사용할 수 있는 총알이 없거나 잘못된 인덱스입니다.");
            return null;
        }
    }

    // 총알을 풀로 되돌려놓는 함수
    public void ReturnBullet(GameObject bullet, int bulletTypeIndex)
    {
        bullet.SetActive(false);

        if (bulletTypeIndex >= 0 && bulletTypeIndex < bulletPools.Count)
        {
            bulletPools[bulletTypeIndex].Enqueue(bullet);
        }
        else
        {
            Debug.Log("잘못된 인덱스로 총알을 되돌리려 했습니다.");
        }
    }
}
