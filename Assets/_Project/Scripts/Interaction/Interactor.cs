using System;
using UnityEngine;

public class Interactor : MonoBehaviour
{

    [SerializeField] private LayerMask _interactableLayerMask;
    [SerializeField] private float _interactionDistance;
    
    private InputReader _input;
    private Camera _camera;
    
    private void Start()
    {
        _input = ServiceManager.GetService<InputService>().InputReader;
        _camera = ServiceManager.GetService<CameraService>().MainCamera;
        
        _input.OnInteractPressed += OnInteract;
    }

    private void OnDisable()
    {
        _input.OnInteractPressed -= OnInteract;
    }


    private void OnInteract()
    {
        var screenPosX = Screen.width / 2;
        var screenPosY = Screen.height / 2;

        var screenPos = new Vector3(screenPosX, screenPosY, 0);

        var ray = _camera.ScreenPointToRay(screenPos);

        if (!Physics.Raycast(ray, out var hit, _interactionDistance, _interactableLayerMask)) return;
        
        if (hit.transform.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact();
        }

    }
}