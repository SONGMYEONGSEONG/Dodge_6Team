using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ItemController : MonoBehaviour , iPoolable<ItemController>
{
    public event Action<ItemController> OnEventPushObject;

    [SerializeField] public ItemSO ItemSO;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //������Ʈ Ǫ�� �ڵ� �ۼ� 
            //gameObject.SetActive(false);
            OnEventPushObject?.Invoke(this);
        }
    }
}
