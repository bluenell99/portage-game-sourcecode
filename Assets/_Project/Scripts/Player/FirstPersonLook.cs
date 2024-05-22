using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField] private CameraSettings _cameraSettings;

    private InputReader _inputReader;
    private Vector3 _startingRotation;

    private void Start()
    {
        InputUtilities.SetCursorLockState(true);
        _inputReader = ServiceManager.GetService<InputService>().InputReader;
    }

    protected void LateUpdate()
    {
        _startingRotation.x += _inputReader.Look.x * Time.deltaTime * _cameraSettings.XSensitivity;
        _startingRotation.y += _inputReader.Look.y * Time.deltaTime * _cameraSettings.XSensitivity;
        _startingRotation.y = Mathf.Clamp(_startingRotation.y, _cameraSettings.VerticalClamp.x,
            _cameraSettings.VerticalClamp.y);
        transform.rotation = Quaternion.Euler(-_startingRotation.y, _startingRotation.x, 0);
    }
    
    
}

