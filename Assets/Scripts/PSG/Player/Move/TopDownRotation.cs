using System;
using UnityEngine;

public class TopDownRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerRender;
    [SerializeField] private Transform playerPivot;

    private TopDownController controller;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
    }
    private void Start()
    {
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 _direction)
    {
        Rotaiton(_direction);
    }

    private void Rotaiton(Vector2 _direction)
    {
        float rot2 = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg - 90f;

        playerPivot.rotation = Quaternion.Euler(0, 0, rot2);
    }
}