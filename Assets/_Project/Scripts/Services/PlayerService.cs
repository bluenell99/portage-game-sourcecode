using UnityEngine;

public class PlayerService : Service
{
    public Player Player { get; private set; }

    public void SetPlayer(Player p)
    {
        Player = p;
    }

    public void EnablePlayerController(bool enable)
    {
        Player.Movement.EnableMovement(enable);
    }
}