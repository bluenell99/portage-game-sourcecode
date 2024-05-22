using System;
using UnityEngine;
using UnityEngine.Serialization;

public class MinigameService : Service
{
    [FormerlySerializedAs("CurrentMinigame")] public MinigameBase _currentMinigameBase;
    public MinigameBase CreateMinigame<T>() where T : MinigameBase
    {
        Debug.Log($"Creating new minigame: {typeof(T)}");
        GameObject go = new GameObject($"Minigame System: {typeof(T)}");
        go.transform.parent = this.transform;
        return go.AddComponent<T>();
    }

    public void Dispose(MinigameBase minigameBase)
    {
        Debug.Log($"Disposing of minigame");
        Destroy(minigameBase.gameObject);
        _currentMinigameBase = null;
    }

}