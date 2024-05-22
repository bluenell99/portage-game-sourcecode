using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInput;

[CreateAssetMenu(menuName = "Portage/Input/Input Reader", fileName = "New Input Reader")]
public class InputReader : ScriptableObject, IPlayerActions
{

    private PlayerInput _input;
   
    public Vector2 Move => _input.Player.Move.ReadValue<Vector2>();
    public Vector2 Look => _input.Player.Look.ReadValue<Vector2>();
    
    public event Action OnInteractPressed;
    public event Action OnCycleInventoryPressed;
    public event Action<bool> OnJumpPressed;
    public event Action<bool> OnCrouchPressed;
    public event Action<bool> OnSprintPressed;

    private void OnEnable()
    {
        if (_input == null)
        {
            _input = new PlayerInput();
            _input.Player.SetCallbacks(this);
        }
    }
    
    public void Enable()
    {
        _input.Enable();
    }
    
    public void OnMove(InputAction.CallbackContext context) { }

    public void OnLook(InputAction.CallbackContext context) { }

    public void OnFire(InputAction.CallbackContext context) { }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
            OnInteractPressed?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                OnJumpPressed?.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                OnJumpPressed?.Invoke(false);
                break;
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                OnCrouchPressed?.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                OnCrouchPressed?.Invoke(false);
                break;
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                OnSprintPressed?.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                OnSprintPressed?.Invoke(false);
                break;
        }
    }

    public void OnCycleInventory(InputAction.CallbackContext context)
    {
        if (context.started)
            OnCycleInventoryPressed?.Invoke();
    }
}
