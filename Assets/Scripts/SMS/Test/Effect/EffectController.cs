using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour , iPoolable<EffectController>
{
    public event Action<EffectController> OnEventPushObject;

    private SpriteRenderer renderer;
    private Animator animator;

    [SerializeField] public EffectSO _EffectSO;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float animTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (animTime >= 1.0f)
        {
            // 애니메이션 종료
            OnEventPushObject?.Invoke(this);
        }
    }

}
