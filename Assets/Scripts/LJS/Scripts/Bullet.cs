using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Bullet : MonoBehaviour
//{
//    public float speed;
//    public int damage;

//    void Update()
//    {
//        // 총알이 앞으로 나아가는 코드
//        transform.Translate(Vector3.forward * speed * Time.deltaTime);
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        // 충돌 처리 (예: 적에게 데미지를 주고, 총알을 풀에 반환)
//    }

//20241017 송명성 - 투사체 코드 상속 추가 
public class Bullet : MonoBehaviour, iPoolable<Bullet>
{
    public event Action<Bullet> OnEventPushObject;

    [SerializeField] public DefaultBulletSO defaultBulletSO;

    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void OnMove()
    {
        // 총알이 앞으로 나아가는 코드
        rigid.velocity = (transform.up * defaultBulletSO.bulletSpeed * Time.deltaTime);
    }

    public void OnMove(Vector2 playerDir)
    {
        // 총알이 앞으로 나아가는 코드
        rigid.velocity = (playerDir * defaultBulletSO.bulletSpeed * Time.deltaTime);
    }

    protected void CompletePurPose()
    {
        OnEventPushObject?.Invoke(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CompletePurPose();
    }
}
