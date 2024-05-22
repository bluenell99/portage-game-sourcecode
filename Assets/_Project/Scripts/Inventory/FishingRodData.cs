using UnityEngine;

[CreateAssetMenu(menuName = "Portage/Tool Data/Create FishingRodData", fileName = "FishingRodData", order = 0)]
public class FishingRodData : ToolData
{
    public Vector2 CatchTimeRange;
    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}