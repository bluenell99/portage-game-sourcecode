using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepService : Service
{
    [SerializeField] FootstepCollection[] _footstepCollections;
    private TerrainLayer _currentLayer;

}
