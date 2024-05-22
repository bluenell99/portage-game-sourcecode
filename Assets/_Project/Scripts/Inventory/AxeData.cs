using UnityEngine;

[CreateAssetMenu(menuName = "Portage/Tool Data/Create Axe Data", fileName = "AxeData", order = 0)]
public class AxeData : ToolData
{
    public float Sharpness;
    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}