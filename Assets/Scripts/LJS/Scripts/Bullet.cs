using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;

    void Update()
    {
        // 총알이 앞으로 나아가는 코드
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // 충돌 처리 (예: 적에게 데미지를 주고, 총알을 풀에 반환)
    }
}
