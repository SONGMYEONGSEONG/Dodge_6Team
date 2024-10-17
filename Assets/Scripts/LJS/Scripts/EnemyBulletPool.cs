using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour
{
    public GameObject[] bulletPrefabs; // ���� �Ѿ� ������ �迭
    public int poolSize = 10;
    // �� �����ո��� ���� Ǯ�� �����ϱ� ���� ����Ʈ
    private List<Queue<GameObject>> bulletPools;

    void Start()
    {
        bulletPools = new List<Queue<GameObject>>();

        // �� �����տ� ���� Ǯ�� ����
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

    // Ư�� ������ �Ѿ��� Ǯ���� ������ �Լ�
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
            Debug.Log("Ǯ�� ����� �� �ִ� �Ѿ��� ���ų� �߸��� �ε����Դϴ�.");
            return null;
        }
    }

    // �Ѿ��� Ǯ�� �ǵ������� �Լ�
    public void ReturnBullet(GameObject bullet, int bulletTypeIndex)
    {
        bullet.SetActive(false);

        if (bulletTypeIndex >= 0 && bulletTypeIndex < bulletPools.Count)
        {
            bulletPools[bulletTypeIndex].Enqueue(bullet);
        }
        else
        {
            Debug.Log("�߸��� �ε����� �Ѿ��� �ǵ����� �߽��ϴ�.");
        }
    }
}
