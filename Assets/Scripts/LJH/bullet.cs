using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public float bulletSpeed = 10f; 
    public float specialAngle = 35f; 
    public int bulletCount = 6; 

    void Update()
    {
        // 스페이스바로 총알 발사
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet(Vector2.right); // 오른쪽으로 발사
        }

        // A 키로 부채꼴 특수 발사
        if (Input.GetKeyDown(KeyCode.A))
        {
            FireSpecialBullets();
        }
    }

    void FireBullet(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    void FireSpecialBullets()
    {
        for (int i = -bulletCount / 2; i <= bulletCount / 2; i++)
        {
            float angle = specialAngle * i / bulletCount; // 각도 계산
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.right; // 방향 계산
            FireBullet(direction);
        }
    }
}
