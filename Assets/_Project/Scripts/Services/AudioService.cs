using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioService : Service
{
    private AudioSource _source;
    protected override void Awake()
    {
        base.Awake();

        if (!TryGetComponent(out _source))
        {
            _source = gameObject.AddComponent<AudioSource>();
            _source.spatialBlend = 0;
        }
        
    }
    
    public void PlayRandomSoundFromCollection(List<AudioClip> clips)
    {
        int random = Random.Range(0, clips.Count);
        
        _source.PlayOneShot(clips[random]);
        
    }
}
