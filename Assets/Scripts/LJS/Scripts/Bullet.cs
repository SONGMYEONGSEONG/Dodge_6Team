using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;

    void Update()
    {
        // �Ѿ��� ������ ���ư��� �ڵ�
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // �浹 ó�� (��: ������ �������� �ְ�, �Ѿ��� Ǯ�� ��ȯ)
    }
}
