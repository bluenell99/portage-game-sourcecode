using System;
using UnityEngine;

[RequireComponent(typeof(MovementBehaviour))]
[RequireComponent(typeof(GroundDetector))]
public class Player : IEntity
{
    [SerializeField] private MovementBehaviour _movement;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private ToolsBelt _toolsBelt;
    

    public ToolsBelt ToolsBelt => _toolsBelt;
    public MovementBehaviour Movement => _movement;
    public GroundDetector GroundDetector => _groundDetector;
    
    private InputReader _inputReader;
    private Transform _mainCamera;

    public bool IsGroundedAndMoving() => _movement.IsMoving && _groundDetector.IsGrounded;

    public void Awake()
    {
        ServiceManager.GetService<PlayerService>().SetPlayer(this);
    }

    private void Start()
    {
        HandleServices();
        
        _inputReader.OnJumpPressed += _movement.OnJump;
        _inputReader.OnCrouchPressed += _movement.OnCrouch;
        _inputReader.OnSprintPressed += _movement.OnSprint;
        _inputReader.OnCycleInventoryPressed += _toolsBelt.NextTool;

        Movement.EnableMovement(true);
    }

    private void OnDestroy()
    {
        _inputReader.OnJumpPressed -= _movement.OnJump;
        _inputReader.OnCrouchPressed -= _movement.OnCrouch;
        _inputReader.OnSprintPressed -= _movement.OnSprint;
        _inputReader.OnCycleInventoryPressed -= _toolsBelt.NextTool;
    }

    private void HandleServices()
    {
        _inputReader = ServiceManager.GetService<InputService>().InputReader;
        _mainCamera = ServiceManager.GetService<CameraService>().MainCamera.transform;
    }

    private void FixedUpdate()
    {
        if (!Movement.MovementEnabled) return;
        
        var movementDirection = (_mainCamera.forward * _inputReader.Move.y + _mainCamera.right * _inputReader.Move.x).normalized;
        _movement.Move(movementDirection);
    }
}

