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
        // �ǰ� ��Ÿ�� �����ϱ�
        if (enemyCollisionCooldown && (collision.CompareTag("Enemy") || collision.CompareTag("Bullet")))
        {
            SoundManager.Instance.PlaySFX(SoundManager.Sfx.Hit);
            if (statHandler.ProjectilePower > 1)
            {
                statHandler.ProjectilePower--;// �ǰݵǸ� �Ŀ��� 1�� ����
            }
            StartCoroutine(SpriteColorTime());
            enemyCollisionCooldown = false;
            GameManager.Instance.CurPlayerLife--;
            Debug.Log("�浹, ��ٿ� ����");

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
        Debug.Log("��ٿ� ����");
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
        TriggerCoolDown();//0.4���� �ǰ� ��Ÿ��
    }
    
    private IEnumerator ApplyItemTime(ItemSO itemSO, float duration)
    {
        // ������ ȿ�� ����
        statHandler.ProjectilePower += itemSO.ProjectilePower;
        statHandler.AttackSpeed -= itemSO.AttackSpeed;
        statHandler.Speed += itemSO.Speed;
        GameManager.Instance.CurPlayerLife += itemSO.Shield;

        //���� �������� ���ӸŴ����� ������ ����
        GameManager.Instance.GetScore(itemSO.Score);
        yield return null;

        Debug.Log("������ ȿ�� ����. ���� �ð�: " + duration + "��");

        // �־��� �ð�(duration) ���� ���
        yield return new WaitForSeconds(duration);

        // ���� ���·� ����
        //statHandler.ProjectilePower -= itemSO.ProjectilePower;
        statHandler.AttackSpeed += itemSO.AttackSpeed;
        statHandler.Speed -= itemSO.Speed;
        statHandler.Shield -= itemSO.Shield;

        Debug.Log("������ ȿ�� ����.");
    }
}
