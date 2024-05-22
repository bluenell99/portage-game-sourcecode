using System.Collections;
using UnityEngine;

public class AutomaticFootstepBehaviour : FootstepBehaviour
{

    [SerializeField] private float _interval;
    private Coroutine _footstepCoroutine;
    
    protected override void Start()
    {
        base.Start();
        StartCoroutine(CO_Step());
    }

    private void Update()
    {
        if (Player.IsGroundedAndMoving() && _footstepCoroutine == null)
        {
            _footstepCoroutine = StartCoroutine(CO_Step());
        }
        
        if (!Player.IsGroundedAndMoving() && _footstepCoroutine != null)
        {
            StopCoroutine(_footstepCoroutine);
            _footstepCoroutine = null;
        }
    }

    private IEnumerator CO_Step()
    {
        while (true)
        {
            Step();
            yield return new WaitForSeconds(_interval);
        }
    }
    
}