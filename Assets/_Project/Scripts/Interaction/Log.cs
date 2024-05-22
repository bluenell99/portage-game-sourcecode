using System.Threading.Tasks;
using UnityEngine;

public class Log : ToolInteractable
{
    private void OnValidate()
    {
        gameObject.layer = LayerMask.NameToLayer("Interactable");
    }
    public override Task Execute()
    {
        Destroy(gameObject);
        return Task.CompletedTask;
    }
}