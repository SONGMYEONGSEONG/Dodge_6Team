using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*20241017 - �۸��� �������̽� �߰�*/
//public class EnemyController : MonoBehaviour
public class EnemyController : MonoBehaviour, iPoolable<EnemyController>
{
    [SerializeField] protected GameObject findPlayer;
    [SerializeField] protected GameObject explosionObj;

    protected GameObject enemyspriteRotation;
    public Rigidbody2D rb;

    /*20241017 - �۸��� ��ġ ���� ShooterEnemyController -> EnemyController*/
    /*20241017 - �۸��� ���������� ���� private -> protected*/
    [SerializeField] protected EnemySO enemySO;
    /*20241017 - �۸��� �����Ҽ� �ְ� ������Ƽ ����*/
    public EnemySO EnemySO { get { return enemySO; } }

    /*20241017 - �۸��� ������Ʈ Ǯ���� ���� �̺�Ʈ �߰�*/
    public event Action<EnemyController> OnEventPushObject;
    public event Action<EnemyController> OnEventDieObject;
    public event Func<Vector2, ItemController> OnEventDropItem;

    protected void CompletePurPose()
    {
        OnEventPushObject?.Invoke(this);
    }
    protected void EnemyDie()
    {
        OnEventDieObject?.Invoke(this);
    }

    public void Start()
    {
        enemyspriteRotation = gameObject.transform.GetChild(0).gameObject;
        findPlayer = GameObject.FindGameObjectWithTag("Player").gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    public void EnemyMove(GameObject _player, float speed)
    {

        Vector3 direction = (_player.transform.position - transform.position).normalized;
        rb.velocity = direction * speed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        enemyspriteRotation.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            OnDieEffect();
            Invoke("DropItem", 0.1f);
            EnemyDie();
            CompletePurPose();
        }
        else if (collision.CompareTag("Player") || collision.CompareTag("ObjectPush"))
        {
            CompletePurPose();
        }


    }

    private void OnDieEffect()
    {
        GameObject explosionIns = Instantiate(explosionObj, gameObject.transform.position, Quaternion.identity);
    }

    public void DropItem()
    {
        if (OnEventDropItem?.Invoke(transform.position) == null)
        {
            return;
        }
        //itemSpawnManager.RandomPoolObject(transform.position);
        //int itemListRandom = random.Next(0, );
        ////������Ʈ Ǯ�� �Ұ� 
        //Instantiate(itemObj[itemListRandom], gameObject.transform.position, Quaternion.identity);  
    }


}
