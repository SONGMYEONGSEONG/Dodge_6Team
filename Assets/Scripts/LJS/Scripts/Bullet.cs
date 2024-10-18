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
//        // �Ѿ��� ������ ���ư��� �ڵ�
//        transform.Translate(Vector3.forward * speed * Time.deltaTime);
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        // �浹 ó�� (��: ������ �������� �ְ�, �Ѿ��� Ǯ�� ��ȯ)
//    }

//20241017 �۸� - ����ü �ڵ� ��� �߰� 
public class Bullet : MonoBehaviour, iPoolable<Bullet>
{
    public event Action<Bullet> OnEventPushObject;

    [SerializeField] public DefaultBulletSO defaultBulletSO;

    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    public void OnMove(Vector2 playerDir)
    {
        // �Ѿ��� ������ ���ư��� �ڵ�
        rigid.AddForce(playerDir * defaultBulletSO.bulletSpeed,ForceMode2D.Impulse);
    }

    protected void CompletePurPose()
    {
        OnEventPushObject?.Invoke(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("ObjectPush"))
        {
            CompletePurPose();
        }
    }
}
