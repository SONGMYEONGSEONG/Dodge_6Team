using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera camera;

    InputActionAsset inputAction;

    private void Awake()
    {
        camera = Camera.main;
        inputAction = GetComponent<PlayerInput>().actions;
    }

    private void Start()
    {
        GameManager.Instance.OnEventGameOver += OnDisEnablePlayerInput;
    }

    public void OnEnablePlayerInput()
    {
        inputAction.FindActionMap("PlayerAction").Enable();
    }

    public void OnDisEnablePlayerInput()
    {
        inputAction.FindActionMap("PlayerAction").Disable();
    }

    public void OnMove(InputValue _value)
    {
        Vector2 moveInput = _value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
    public void OnLook(InputValue _value)
    {
        Vector2 newAim = _value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }

    public void OnFire(InputValue _value)
    {
        isAttacking = _value.isPressed; 
        //Debug.Log(isAttacking);
    }
}
