using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5f; // 장애물 이동 속도
    public float deleteDistance = 15f; // 삭제할 거리
    private Transform player; // 플레이어의 Transform

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // 플레이어 찾기
        SetInitialDirection(); // 장애물 초기 방향 설정
    }

    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime); // 현재 방향으로 이동

        // 플레이어와의 거리 체크
        //float distance = Vector2.Distance(transform.position, player.position);
        //if (distance > deleteDistance) // 일정 거리 이상이면 삭제
        //{
        //    Destroy(gameObject);
        //}
    }

    void SetInitialDirection()
    {
        Vector2 spawnPosition;
        Vector2 direction;

        int randomSide = Random.Range(0, 4); // 0: 위, 1: 아래, 2: 왼쪽, 3: 오른쪽
        switch (randomSide)
        {
            case 0: // 위에서 생성
                spawnPosition = new Vector2(Random.Range(-8f, 8f), 6f);
                direction = Vector2.down;
                break;
            case 1: // 아래에서 생성
                spawnPosition = new Vector2(Random.Range(-8f, 8f), -6f);
                direction = Vector2.up;
                break;
            case 2: // 왼쪽에서 생성
                spawnPosition = new Vector2(-9f, Random.Range(-4f, 4f));
                direction = Vector2.right;
                break;
            case 3: // 오른쪽에서 생성
                spawnPosition = new Vector2(9f, Random.Range(-4f, 4f));
                direction = Vector2.left;
                break;
            default:
                spawnPosition = Vector2.zero;
                direction = Vector2.zero;
                break;
        }

        transform.position = spawnPosition; // 장애물 위치 설정
        transform.up = direction; // 장애물의 방향 설정
    }
}