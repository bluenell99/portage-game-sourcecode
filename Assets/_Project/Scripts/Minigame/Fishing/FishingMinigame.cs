using System.Threading.Tasks;
using PaviaJamie.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishingMinigame : MinigameBase
{

    private CountdownTimer _waitingTimer;
    private CountdownTimer _escapeTimer;
    private PlayerService _playerService;

    private MinigameService _minigameService;
    private FishData _spawnedFish;

    private bool _hasCaughtFish;
    
    public override async Task<bool> Initialise(MinigameService service, MinigameDataBase minigameData)
    {
        // if base has successfully initialised, try initialise Fishing minigame
        if (await base.Initialise(service, minigameData))
        {
            MinigameDataBase = minigameData;
            _minigameService = service;
            _playerService = ServiceManager.GetService<PlayerService>();
            _hasCaughtFish = false;
            return true;
        }

        return false;
    }

    public override void StartMinigame()
    {
        if (MinigameDataBase is not FishingMinigameData fishingData) return;
        _playerService.EnablePlayerController(false);

        CreateFish(fishingData);
    }

    public override void InteractWithMinigame()
    {
        // player interacted before fish has spawned
        if (_waitingTimer.IsRunning)
        {
            EndMinigame();
            return;
        }
        
        // player interacted whilst fish is trying to escape
        if (_escapeTimer.IsRunning)
        {
            _hasCaughtFish = true;
            //TODO UI for success
            
            Debug.Log($"FISH CAUGHT! - {_spawnedFish.FishName}");
            EndMinigame();
        }
    }
    
    // Spawns a fish to catch
    private void CreateFish(FishingMinigameData fishingData)
    {
        // Select a fish from the list based on Rarity
        _spawnedFish = RarityUtility.SelectByRarity(fishingData.CatchableFish);
        Debug.Log($"Spawned fish: {_spawnedFish.FishName}");
        
        // Setup timer
        float waitingTime = Random.Range(_spawnedFish.CatchTime.x, _spawnedFish.CatchTime.y);
        _waitingTimer = new CountdownTimer(waitingTime);
        _waitingTimer.Start();
        _waitingTimer.OnTimerStop += TryCatchFish;
        
    }

    
    // try and catch the spawned fish
    private void TryCatchFish()
    {
        Debug.Log($"Bite: {_spawnedFish.FishName}");
        
        // setup timer
        float escapeTime = Random.Range(_spawnedFish.EscapeTime.x, _spawnedFish.EscapeTime.y);
        _escapeTimer = new CountdownTimer(escapeTime);
        _escapeTimer.Start();
        _escapeTimer.OnTimerStop += () =>
        {
            if (!_hasCaughtFish)
            {
                //TODO UI for failure
                Debug.Log("Escaped!");
            }
            
            EndMinigame();
        };
        
    }

    private void Update()
    {
        // tick timers
        if (_waitingTimer != null)
            _waitingTimer.Tick(Time.deltaTime);

        if (_escapeTimer != null)
           _escapeTimer.Tick(Time.deltaTime);
    }
    
    // Shuts down and stops minigame
    private void EndMinigame()
    {
        _playerService.EnablePlayerController(true);
        _minigameService.Dispose(this);
    }
}