using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹
    public float bulletSpeed = 10f; // 총알 속도
    public float specialAngle = 30f; // 부채꼴 각도
    public int bulletCount = 5; // 부채꼴에서 발사할 총알 수

    void Update()
    {
        // 마우스 위치에 따라 플레이어 회전
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // 스페이스바로 총알 발사
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet(direction); // 마우스 방향으로 발사
        }

        // A 키로 부채꼴 특수 기능
        if (Input.GetKeyDown(KeyCode.A))
        {
            FireSpecialBullets(direction);
        }
    }

    void FireBullet(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    void FireSpecialBullets(Vector2 direction)
    {
        for (int i = -bulletCount / 2; i <= bulletCount / 2; i++)
        {
            float angle = specialAngle * i / bulletCount; // 각도 계산
            Vector2 bulletDirection = Quaternion.Euler(0, 0, angle) * direction; // 방향 계산
            FireBullet(bulletDirection);
        }
    }
}
