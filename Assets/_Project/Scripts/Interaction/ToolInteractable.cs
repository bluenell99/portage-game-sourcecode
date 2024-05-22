using System;
using System.Threading.Tasks;
using UnityEngine;

public abstract class ToolInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private ToolType _requiredToolType;
    
    private ToolsBelt _playerToolsBelt;

    /// <summary>
    /// Executes the interactable's function
    /// </summary>
    public abstract Task Execute();
    
    /// <summary>
    /// Validates that active tool is the same type as the required tool for this interactable
    /// </summary>
    /// <returns></returns>
    public bool ValidateTool()
    {
        // Access tools belt
        if (_playerToolsBelt == null)
            _playerToolsBelt = ServiceManager.GetService<PlayerService>().Player.ToolsBelt;

        ToolData activeTool = _playerToolsBelt.ActiveTool;
        
        return _requiredToolType switch
        {
            ToolType.Axe => activeTool is AxeData,
            ToolType.FishingRod => activeTool is FishingRodData,
            ToolType.Torch => activeTool is FishingRodData,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    /// <summary>
    /// On initial interaction
    /// </summary>
    public void Interact()
    {
        if (ValidateTool())
        {
            Execute();
            return;
        }

        Debug.Log("Required tool not equipped");
        
    }
}