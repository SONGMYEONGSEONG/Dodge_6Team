using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private StatHandler statHandler;
    private bool enemyCollisionCooldown = true;
    private void Start()
    {
        statHandler = GetComponent<StatHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 피격 쿨타임 구현하기
        if(enemyCollisionCooldown && (collision.CompareTag("Enemy") || collision.CompareTag("Bullet")))
        {
            enemyCollisionCooldown = false;
            Debug.Log("충돌, 쿨다운 시작");
            Invoke("TriggerCoolDown", 1f);
            
        }
        if (collision.CompareTag("Item"))
        {
            ItemController itemController = collision.GetComponent<ItemController>();
            ItemSO collisionItemSO = itemController.itemSO;

            statHandler.ProjectilePower += collisionItemSO.ProjectilePower;
            statHandler.AttackSpeed -= collisionItemSO.AttackSpeed;
            statHandler.Speed += collisionItemSO.Speed;
            statHandler.Shield += collisionItemSO.Shield;
            statHandler.point += collisionItemSO.point;
        }
    }
    private void TriggerCoolDown()
    {
        enemyCollisionCooldown = true;
        Debug.Log("쿨다운 해제");
    }
}
