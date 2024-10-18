using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] public ItemSO itemSO;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //오브젝트 푸쉬 코드 작성 
            gameObject.SetActive(false);
        }
    }
}
