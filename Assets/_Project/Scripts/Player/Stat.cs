using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Stat : MonoBehaviour
{
    [SerializeField] private StatEventChannel _statEventChannel;
    [SerializeField] private int _max;

    private int _current;
    public int Max => _max;
    public int Current => _current;
    
    private void Awake()
    {
        _current = _max;
    }

    private void Start()
    {
        PublishEvent();
    }

    protected void UpdateStat(int amount)
    {
        _current += amount;
        PublishEvent();
    }

    private void PublishEvent()
    {
        if (_statEventChannel)
        {
            _statEventChannel.Invoke(this);
        }
    }
   
}