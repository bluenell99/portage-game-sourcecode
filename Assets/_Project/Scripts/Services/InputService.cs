using UnityEngine;

public class InputService : Service
{
    [SerializeField] private InputReader _inputReader;
    public InputReader InputReader => _inputReader;

    protected override void Awake()
    {
        base.Awake();

        if (_inputReader ==  null)
        {
            _inputReader = Resources.Load<InputReader>("Input/PlayerInput");
        }

        _inputReader.Enable();
    }
}