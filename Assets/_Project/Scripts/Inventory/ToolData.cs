using UnityEngine;

public abstract class ToolData : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite InventoryIcon;
    public abstract void Use();

}