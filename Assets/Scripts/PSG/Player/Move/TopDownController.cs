using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;
    [SerializeField] private StatHandler statHandler;
    protected bool isAttacking {  get; set; }

    private float timeSinceLastAttack = float.MaxValue;
    private void Start()
    {
        statHandler = GetComponent<StatHandler>();
    }
    private void Update()
    {
        HandleAttackDelay();
    }
    private void HandleAttackDelay()
    {
        if(timeSinceLastAttack < statHandler.AttackSpeed)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if(isAttacking)
        {
            timeSinceLastAttack = 0f;
            CallAttackEvent();
        }
    }

    public void CallMoveEvent(Vector2 _direction)
    {
        OnMoveEvent?.Invoke(_direction);
    }

    public void CallLookEvent(Vector2 _direction) 
    {
        OnLookEvent?.Invoke(_direction); 
    }

    private void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
        //isAttacking = false;
    }
}
