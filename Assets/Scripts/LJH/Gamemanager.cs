using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject obstaclePrefab; // 장애물 프리팹
    public float spawnInterval = 2f; // 생성 주기

    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnInterval, spawnInterval);
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, Vector3.zero, Quaternion.identity); // 장애물 생성
    }
}
