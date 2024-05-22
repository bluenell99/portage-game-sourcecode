using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMovement : MovementBehaviour
{
    private Rigidbody _rigidBody;
    private Transform _mainCamera;
    private Player _player;

    [Header("Movement")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _sprintMultiplier;
    
    [Header("Jump")]
    [SerializeField] private float _jumpMaxHeight;
    [SerializeField] private float _jumpGravityMultiplier;

    [Header("Crouch")] 
    [SerializeField] private float _crouchSpeedMultiplier;

    private float _jumpVelocity;
    private float _speed;



    public bool IsCrouched { get; private set; }
    public bool IsSprinting { get; private set; }
    
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();
        _speed = _movementSpeed;
        
        InitRigidBody();
    }

    
    private void InitRigidBody()
    {
        _rigidBody.useGravity = true;
        _rigidBody.isKinematic = false;
        _rigidBody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    /// <summary>
    /// Handles movement in given direction
    /// </summary>
    /// <param name="direction"></param>
    public override void Move(Vector3 direction)
    {
        direction.y = 0;
        Vector3 velocity = direction * (_speed * Time.fixedDeltaTime);

        if (velocity != Vector3.zero)
        {
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }
        
        _rigidBody.velocity = new Vector3(velocity.x, _rigidBody.velocity.y, velocity.z);

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, lookRotation, _rotationSpeed);
        }
    }
    
    /// <summary>
    /// Callback when Jump button is pressed
    /// </summary>
    /// <param name="pressed"></param>
    public override void OnJump(bool pressed)
    {
        if (_player.GroundDetector.IsGrounded)
        {
            _jumpVelocity = Mathf.Sqrt(2 * _jumpMaxHeight * Mathf.Abs(Physics.gravity.y));
            
            var velocity = _rigidBody.velocity;
            velocity = new Vector3(velocity.x, _jumpVelocity, velocity.x);
            _rigidBody.velocity = velocity;
        }
        else
        {
            _jumpVelocity += Physics.gravity.y * _jumpGravityMultiplier * Time.fixedDeltaTime;
        }
    }

    /// <summary>
    /// Callback when sprint button is pressed
    /// </summary>
    /// <param name="pressed"></param>
    public override void OnSprint(bool pressed)
    {
        if (pressed & !IsCrouched)
            _speed = _movementSpeed * _sprintMultiplier;
        else
            _speed = _movementSpeed;
        
        IsSprinting = pressed;
    }

    /// <summary>
    /// Callback when crouch button is pressed
    /// </summary>
    /// <param name="pressed"></param>
    public override void OnCrouch(bool pressed)
    {
        if (pressed)
            _speed = _movementSpeed * _crouchSpeedMultiplier;
        else
            _speed = _movementSpeed;
        
        IsCrouched = pressed;
    }
}