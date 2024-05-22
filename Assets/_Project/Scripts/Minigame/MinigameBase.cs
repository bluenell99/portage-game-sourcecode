using System.Threading.Tasks;
using UnityEngine;

public abstract class MinigameBase : MonoBehaviour
{
    public bool IsRunning { get; private set; }
    public MinigameDataBase MinigameDataBase { get; protected set; }

    /// <summary>
    /// Initialises a new minigame
    /// </summary>
    /// <param name="minigameService">The active minigame service</param>
    /// <param name="minigameData">Data required for minigame</param>
    /// <returns>Successfully initialised</returns>
    public virtual async Task<bool> Initialise(MinigameService minigameService , MinigameDataBase minigameData)
    {
        if (minigameService._currentMinigameBase != null)
        {
            Debug.Log("Minigame already active");
            Dispose(minigameService);
            return false;
        }
        
        minigameService._currentMinigameBase = this;
        Debug.Log($"Initialising {this}");
        IsRunning = true;
        return true;
    }

    /// <summary>
    /// Starts the minigame
    /// </summary>
    public abstract void StartMinigame();
    
    /// <summary>
    /// Disposes of minigame and removes instance from scene
    /// </summary>
    /// <param name="service"></param>
    protected void Dispose(MinigameService service)
    {
        Debug.Log($"Disposing of minigame: {this}");
        IsRunning = false;
        Destroy(this.gameObject);

    }

    /// <summary>
    /// Multiple interaction of minigame when game is running
    /// </summary>
    public abstract void InteractWithMinigame();
}