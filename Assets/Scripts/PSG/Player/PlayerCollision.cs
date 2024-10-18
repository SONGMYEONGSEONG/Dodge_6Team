using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private StatHandler statHandler;
    // 적 충돌 쿨타임
    private bool enemyCollisionCooldown = true;
    //아이템 충돌 쿨타임
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
        // 피격 쿨타임 구현하기
        if(enemyCollisionCooldown && (collision.CompareTag("Enemy") || collision.CompareTag("Bullet")))
        {
            enemyCollisionCooldown = false;
            GameManager.Instance.CurPlayerLife--;
            Debug.Log("충돌, 쿨다운 시작");
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
        Debug.Log("쿨다운 해제");
    }
    private IEnumerator ApplyItemTime(ItemSO itemSO, float duration)
    {
        // 아이템 효과 적용
        statHandler.ProjectilePower += itemSO.ProjectilePower;
        statHandler.AttackSpeed -= itemSO.AttackSpeed;
        statHandler.Speed += itemSO.Speed;
        statHandler.Shield += itemSO.Shield;
        statHandler.point += itemSO.point;

        Debug.Log("아이템 효과 적용. 지속 시간: " + duration + "초");

        // 주어진 시간(duration) 동안 대기
        yield return new WaitForSeconds(duration);

        // 원래 상태로 복구
        statHandler.ProjectilePower -= itemSO.ProjectilePower;
        statHandler.AttackSpeed += itemSO.AttackSpeed;
        statHandler.Speed -= itemSO.Speed;
        statHandler.Shield -= itemSO.Shield;
        statHandler.point -= itemSO.point;

        Debug.Log("아이템 효과 종료.");
    }
}
