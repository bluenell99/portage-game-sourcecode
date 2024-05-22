using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

public class FishingSpot : ToolInteractable
{
    [FormerlySerializedAs("_fishingDataBase")] [SerializeField] private FishingMinigameData _fishingData;
    public override async Task Execute()
    {
        var minigameService = ServiceManager.GetService<MinigameService>();

        // if game is already running, we just interact with it
        if (minigameService._currentMinigameBase != null && minigameService._currentMinigameBase.IsRunning)
        {
            minigameService._currentMinigameBase.InteractWithMinigame();
            return;
        }
        
        // create new minigame
        var minigame = minigameService.CreateMinigame<FishingMinigame>();
        
        if (await minigame.Initialise(minigameService, _fishingData))
        {
            minigame.StartMinigame();
        }
    }
}