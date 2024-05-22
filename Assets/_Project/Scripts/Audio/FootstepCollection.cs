using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Portage/Audio Data/Footstep Collection")]
public class FootstepCollection : ScriptableObject
{
    public TerrainLayer TerrainLayer;
    public List<AudioClip> FootstepSounds = new();
}
