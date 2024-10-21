using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{

    private TopDownController controller;
    private Rigidbody2D movementRigidbody;
    private StatHandler statHandler;
    private Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        statHandler = GetComponent<StatHandler>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }
    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    private void Move(Vector2 _direction)
    {
        movementDirection = _direction;
    }

    private void ApplyMovement(Vector2 _direction)
    {
        _direction = _direction * statHandler.Speed;
        movementRigidbody.velocity = _direction;
    }

}
