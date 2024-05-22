using UnityEngine;

public class ToolItem : MonoBehaviour, IInteractable
{
    public ToolData Data;
    public void Interact()
    {
        ServiceManager.GetService<PlayerService>().Player.ToolsBelt.AddToolToBelt(Data);        
        Destroy(this.gameObject);
    }
}