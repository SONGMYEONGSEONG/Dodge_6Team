using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private StatHandler statHandler;
    // �� �浹 ��Ÿ��
    private bool enemyCollisionCooldown = true;
    //������ �浹 ��Ÿ��
    private bool ProjectilePowerCooldown = true;
    private bool AttackSpeedCooldown = true;
    private bool SpeedCooldown = true;
    private bool ShieldnCooldown = true;

    private void Start()
    {
        statHandler = GetComponent<StatHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ǰ� ��Ÿ�� �����ϱ�
        if(enemyCollisionCooldown && (collision.CompareTag("Enemy") || collision.CompareTag("Bullet")))
        {
            enemyCollisionCooldown = false;
            GameManager.Instance.CurPlayerLife--;
            Debug.Log("�浹, ��ٿ� ����");
            Invoke("TriggerCoolDown", 1f);
            
        }
        if (collision.CompareTag("Item"))
        {
            ItemController itemController = collision.GetComponent<ItemController>();
            ItemSO collisionItemSO = itemController.itemSO;
            StartCoroutine(ApplyItemTime(collisionItemSO, collisionItemSO.CoolTime));
        }
    }
    private void TriggerCoolDown()
    {
        enemyCollisionCooldown = true;
        Debug.Log("��ٿ� ����");
    }
    private IEnumerator ApplyItemTime(ItemSO itemSO, float duration)
    {
        // ������ ȿ�� ����
        statHandler.ProjectilePower += itemSO.ProjectilePower;
        statHandler.AttackSpeed -= itemSO.AttackSpeed;
        statHandler.Speed += itemSO.Speed;
        statHandler.Shield += itemSO.Shield;
        statHandler.point += itemSO.point;

        Debug.Log("������ ȿ�� ����. ���� �ð�: " + duration + "��");

        // �־��� �ð�(duration) ���� ���
        yield return new WaitForSeconds(duration);

        // ���� ���·� ����
        statHandler.ProjectilePower -= itemSO.ProjectilePower;
        statHandler.AttackSpeed += itemSO.AttackSpeed;
        statHandler.Speed -= itemSO.Speed;
        statHandler.Shield -= itemSO.Shield;
        statHandler.point -= itemSO.point;

        Debug.Log("������ ȿ�� ����.");
    }
}
