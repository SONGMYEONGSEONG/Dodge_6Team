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
    [SerializeField] private SpriteRenderer childObjspriteRender;

    private Color originColor;
    private void Start()
    {
        statHandler = GetComponent<StatHandler>();
        childObjspriteRender = gameObject.transform.GetComponentInChildren<SpriteRenderer>();
        originColor = childObjspriteRender.color;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 피격 쿨타임 구현하기
        if (enemyCollisionCooldown && (collision.CompareTag("Enemy") || collision.CompareTag("Bullet")))
        {
            SoundManager.Instance.PlaySFX(SoundManager.Sfx.Hit);
            if (statHandler.ProjectilePower > 1)
            {
                statHandler.ProjectilePower--;// 피격되면 파워가 1씩 감소
            }
            StartCoroutine(SpriteColorTime());
            enemyCollisionCooldown = false;
            GameManager.Instance.CurPlayerLife--;
            Debug.Log("충돌, 쿨다운 시작");

        }
        if (collision.CompareTag("Item"))
        {
            SoundManager.Instance.PlaySFX(SoundManager.Sfx.Item);
            ItemController itemController = collision.GetComponent<ItemController>();
            ItemSO collisionItemSO = itemController._ItemSO;
            StartCoroutine(ApplyItemTime(collisionItemSO, collisionItemSO.CoolTime));
        }
    }
    private void TriggerCoolDown()
    {
        childObjspriteRender.color = originColor;
        enemyCollisionCooldown = true;
        Debug.Log("쿨다운 해제");
    }
    
    private IEnumerator SpriteColorTime()
    {
        for (int i = 0; i < 2; i++)
        {
            childObjspriteRender.color = new Color32(255, 0, 0, 100);
            yield return new WaitForSeconds(0.2f);
            childObjspriteRender.color = new Color32(255, 200, 200, 100);
            yield return new WaitForSeconds(0.2f);
        }
        TriggerCoolDown();//0.4초의 피격 쿨타임
    }
    
    private IEnumerator ApplyItemTime(ItemSO itemSO, float duration)
    {
        // 아이템 효과 적용
        statHandler.ProjectilePower += itemSO.ProjectilePower;
        statHandler.AttackSpeed -= itemSO.AttackSpeed;
        statHandler.Speed += itemSO.Speed;
        GameManager.Instance.CurPlayerLife += itemSO.Shield;

        //점수 아이템은 게임매니저로 데이터 전달
        GameManager.Instance.GetScore(itemSO.Score);
        yield return null;

        Debug.Log("아이템 효과 적용. 지속 시간: " + duration + "초");

        // 주어진 시간(duration) 동안 대기
        yield return new WaitForSeconds(duration);

        // 원래 상태로 복구
        //statHandler.ProjectilePower -= itemSO.ProjectilePower;
        statHandler.AttackSpeed += itemSO.AttackSpeed;
        statHandler.Speed -= itemSO.Speed;
        statHandler.Shield -= itemSO.Shield;

        Debug.Log("아이템 효과 종료.");
    }
}
