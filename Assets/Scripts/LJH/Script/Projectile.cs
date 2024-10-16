using UnityEngine;

public class Projectile : MonoBehaviour
{
    void Update()
    {
        // 화면 밖으로 나가면 삭제
        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 장애물에 부딪히면 삭제
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject); // 장애물 삭제
            Destroy(gameObject); // 발사체 삭제
        }
    }
}