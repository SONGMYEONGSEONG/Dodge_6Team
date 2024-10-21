using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ItemController : MonoBehaviour , iPoolable<ItemController>
{
    public event Action<ItemController> OnEventPushObject;

    [SerializeField] public ItemSO _ItemSO;
    [SerializeField] private float itemFalseDelay = 3.0f;

    Coroutine itemFalseCoroutine;

    private void OnEnable()
    {
        if (itemFalseCoroutine == null)
        {
            StartCoroutine(ItemActiveFalseDelay());
        }
        else
        {
            StopCoroutine(itemFalseCoroutine);
            StartCoroutine(ItemActiveFalseDelay());
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //오브젝트 푸쉬 코드 작성 
            //gameObject.SetActive(false);
            OnEventPushObject?.Invoke(this);
        }
    }
    private IEnumerator ItemActiveFalseDelay()
    {
        yield return new WaitForSeconds(itemFalseDelay);

        OnEventPushObject?.Invoke(this);
    }
}
