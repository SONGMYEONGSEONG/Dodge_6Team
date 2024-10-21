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

    private bool isPushed = false; //충돌처리 함수와 코루틴이 동시에 동작하는것을 방지하기 위한 플래그변수


    private void OnEnable()
    {
        if (itemFalseCoroutine == null)
        {
            itemFalseCoroutine = StartCoroutine(ItemActiveFalseDelay());
        }
        else
        {
            StopCoroutine(itemFalseCoroutine);
            itemFalseCoroutine = StartCoroutine(ItemActiveFalseDelay());
        }
        isPushed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isPushed)
        {
            isPushed = true;
            StopCoroutine(itemFalseCoroutine);
            itemFalseCoroutine = null;
           
            OnEventPushObject?.Invoke(this);
        }
    }

    private IEnumerator ItemActiveFalseDelay()
    {
        yield return new WaitForSeconds(itemFalseDelay);

        if(!isPushed)
        {
            isPushed = true;
            OnEventPushObject?.Invoke(this);
        }
       
    }
}
