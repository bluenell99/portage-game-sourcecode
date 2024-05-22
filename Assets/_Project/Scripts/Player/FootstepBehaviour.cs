using UnityEngine;

public abstract class FootstepBehaviour : MonoBehaviour
{
    [SerializeField] FootstepCollection[] _footstepCollections;
    
    private TerrainLayer _currentLayer;
    private AudioService _audioService;
    protected Player Player { get; set; } 
    
    protected virtual void Start()
    {
        _audioService = ServiceManager.GetService<AudioService>();
        Player = ServiceManager.GetService<PlayerService>().Player;
    }

    protected void Step()
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, Vector3.down, out hit, 3)) return;
        
        if (!hit.transform.TryGetComponent(out Terrain terrain)) return;
        
        var currentLayer = TerrainMaterialUtility.GetLayerName(transform.position, terrain);
        foreach (var collection in _footstepCollections)
        {
            if (currentLayer != collection.TerrainLayer) continue;
            _audioService.PlayRandomSoundFromCollection(collection.FootstepSounds);
            return;
        }
    }
    
}