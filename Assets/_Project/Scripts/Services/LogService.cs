using UnityEngine;

public class LogService : Service
{
    [SerializeField] private bool _enableLogs = false;
    public bool EnableLogs => _enableLogs;

    public void Log(object message)
    {
        if (_enableLogs)
        {
            Debug.Log(message); 
        }
    }
}

