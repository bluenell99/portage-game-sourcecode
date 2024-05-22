using UnityEngine;
using Cinemachine;
public class CameraService : Service
{
    public Camera MainCamera { get; private set; }

    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    
    protected override void Awake()
    {
        base.Awake();
        MainCamera = Camera.main;
    }

    /// <summary>
    /// Sets the virtual cameras look-at target
    /// </summary>
    /// <param name="target">Transform to look at</param>
    public void SetLookatTarget(Transform target)
    {
        if (target == null)
        {
            Debug.LogError("Target is null");
            return;
        }

        _virtualCamera.LookAt = target;

    }


}