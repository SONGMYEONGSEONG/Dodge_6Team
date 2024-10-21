using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ItemController : MonoBehaviour , iPoolable<ItemController>
{
    public event Action<ItemController> OnEventPushObject;

    [SerializeField] public ItemSO _ItemSO;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(ItemActiveFalseDelay());
        if (collision.CompareTag("Player"))
        {
            //오브젝트 푸쉬 코드 작성 
            //gameObject.SetActive(false);
            OnEventPushObject?.Invoke(this);
        }
    }
    private IEnumerator ItemActiveFalseDelay()
    {
        yield return new WaitForSeconds(3);

        OnEventPushObject?.Invoke(this);
    }
}
