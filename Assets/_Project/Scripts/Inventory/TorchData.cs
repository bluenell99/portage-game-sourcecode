using UnityEngine;

[CreateAssetMenu(menuName = "Portage/Tool Data/Create Torch Data", fileName = "TorchData", order = 0)]
public class TorchData : ToolData
{
    public float Brightness;
    public float Range;
    
    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}