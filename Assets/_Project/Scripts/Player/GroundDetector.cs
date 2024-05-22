using UnityEngine;

public class GroundDetector : MonoBehaviour
{

    [SerializeField] private LayerMask _groundLayers;
    [SerializeField] private float _groundDistance;

    [SerializeField] private bool _debug;

    /// <summary>
    /// Checks if object is on the ground
    /// </summary>
    public bool IsGrounded => isGrounded;
    
    private bool isGrounded;
    
    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, _groundDistance, _groundLayers);
    }

    private void OnDrawGizmosSelected()
    {
        if (!_debug) return;
        
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position, _groundDistance);
    }
}