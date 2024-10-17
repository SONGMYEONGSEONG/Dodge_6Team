using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private StatHandler statHandler;
    private void Start()
    {
        statHandler = GetComponent<StatHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") || collision.CompareTag("Bullet"))
        {
            Debug.Log("Ãæµ¹");
        }
    }
}
