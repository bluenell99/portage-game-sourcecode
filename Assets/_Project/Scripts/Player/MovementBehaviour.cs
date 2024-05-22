using UnityEngine;

public abstract class MovementBehaviour : MonoBehaviour
{
    
    public bool MovementEnabled { get; private set; }

    public void EnableMovement(bool value)
    {
        MovementEnabled = value;
    }
    
    public bool IsMoving {get; protected set;}
    
    /// <summary>
    /// Moves the object in given direction
    /// </summary>
    /// <param name="direction">Direction of movement</param>
    public abstract void Move(Vector3 direction);

    public abstract void OnJump(bool pressed);
    public abstract void OnSprint(bool pressed);
    public abstract void OnCrouch(bool pressed);

}

