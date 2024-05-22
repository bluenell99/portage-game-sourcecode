using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepRaycaster : MonoBehaviour
{
    [SerializeField] private float _footstepDelay;
    [SerializeField] FootstepCollection[] _footstepCollections;
    private TerrainLayer _currentLayer;

    private AudioService _audioService;

    private void Start()
    {
        _audioService = ServiceManager.GetService<AudioService>();
    }

    private void Update()
    {
       CheckTerrainLayer(transform);
    }

    public void CheckTerrainLayer(Transform t)
    {
        RaycastHit hit;
        if (Physics.Raycast(t.position, Vector3.down, out hit, 3))
        {
            if (hit.transform.GetComponent<Terrain>() != null)
            {
                Terrain terrain = hit.transform.GetComponent<Terrain>();
                if (_currentLayer != TerrainMaterialUtility.GetLayerName(transform.position, terrain))
                {
                    _currentLayer = TerrainMaterialUtility.GetLayerName(transform.position, terrain);

                    foreach (var collection in _footstepCollections)
                    {
                        if (_currentLayer == collection.TerrainLayer)
                        {
                            _audioService.PlayRandomSoundFromCollection(collection.FootstepSounds);
                        }
                    }
                }
            }
        }
    }
    
}
