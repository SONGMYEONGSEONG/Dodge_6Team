using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*20241017 - 송명성 인터페이스 추가*/
//public class EnemyController : MonoBehaviour
public class EnemyController : MonoBehaviour, iPoolable<EnemyController>
{
    [SerializeField] protected GameObject findPlayer;
    protected GameObject enemyspriteRotation;
    public Rigidbody2D rb;

    /*20241017 - 송명성 위치 변경 ShooterEnemyController -> EnemyController*/
    /*20241017 - 송명성 접근제한자 변경 private -> protected*/
    [SerializeField] protected EnemySO enemySO;
    /*20241017 - 송명성 접근할수 있게 프로퍼티 선언*/
    public EnemySO EnemySO { get { return enemySO; } }

    /*20241017 - 송명성 오브젝트 풀링을 위한 이벤트 추가*/
    public event Action<EnemyController> OnEventPushObject;
    public event Action<int> OnEventDieObject;

    [SerializeField] List<GameObject> itemObj = new List<GameObject>();
    protected void CompletePurPose()
    {
        OnEventPushObject?.Invoke(this);
    }
    protected void GetScore()
    {
        OnEventDieObject?.Invoke(EnemySO.Score);
    }
    /*20241017 - 송명성 오브젝트 풀링을 위한 이벤트 추가*/

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
            //점수 계산
            GetScore();
            /*20241017 - 오브젝트 풀에서 비활성화 하기에 주석처리*/
            //gameObject.SetActive(false);
            DropItem();
            /*20241017 - 송명성 다 사용한 적 객체 오브젝트 풀에 반납*/
            CompletePurPose();
        }
        //화면 밖으로 나갈경우 오브젝트 푸쉬
        //플레이어와 자신 오브젝트 반납
        else if (collision.CompareTag("Player") || collision.CompareTag("ObjectPush"))
        {
            CompletePurPose();
        }


    }

    private void DropItem()
    {
        System.Random random = new System.Random();
        int itemInsRandom = random.Next(1, 101);
        if (itemInsRandom <= 100)
        {
            int itemListRandom = random.Next(0, itemObj.Count);
            //오브젝트 풀링 할것 
            Instantiate(itemObj[itemListRandom], gameObject.transform.position, Quaternion.identity);
        }
    }

    //    private void OnDisable()
    //    {
    //        System.Random random = new System.Random();
    //        int itemInsRandom = random.Next(1, 101);
    //        if(itemInsRandom <= 20)
    //        {
    //            int itemListRandom = random.Next(0, itemObj.Count);
    //            Instantiate(itemObj[itemListRandom],gameObject.transform.position, Quaternion.identity);
    //        }

    //    }

}
