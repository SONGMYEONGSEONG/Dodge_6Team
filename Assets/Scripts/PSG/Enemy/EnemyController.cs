using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected GameObject findPlayer;
    protected GameObject enemyspriteRotation;
    public Rigidbody2D rb;
    [SerializeField]protected bool destroyCheck = true;
    public void Start()
    {
        enemyspriteRotation = gameObject.transform.GetChild(0).gameObject;
        findPlayer = GameObject.FindGameObjectWithTag("Player").gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    public void EnemyMove(GameObject _player,float speed)
    {
        
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        rb.velocity = direction * speed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        enemyspriteRotation.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
