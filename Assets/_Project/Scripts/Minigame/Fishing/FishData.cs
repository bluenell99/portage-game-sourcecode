using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Portage/Entity Data/Fish Data")]
public class FishData : ScriptableObject, IRarity
{
    public string FishName;
    public string FishDesc;
    public FishHabitat[] Habitats;
    public Rarity Rarity => FishRarity;
    public Rarity FishRarity;
    
    public Vector2 CatchTime;
    public Vector2 EscapeTime;
    
}

public enum FishHabitat
{
    Lake,
    River,
    Sea
}