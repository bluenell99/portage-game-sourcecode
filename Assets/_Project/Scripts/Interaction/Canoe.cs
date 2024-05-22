using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canoe : MonoBehaviour, IInteractable
{

    [SerializeField] private Transform _lookTarget;
    
    private void Awake()
    {
        
    }

    public void Interact()
    {
        ServiceManager.GetService<CameraService>().SetLookatTarget(_lookTarget);
    }
}
