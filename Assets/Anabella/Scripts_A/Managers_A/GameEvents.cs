using System;
using UnityEngine;

/// <summary>
/// Class added to handle events 
/// and make them visible across all scripts
/// </summary>
public static class GameEvents 
{
    public static Action CollectNukePowerup;
    public static Action CollectGunPowerup;
    public static Action ActivateNukePowerUp;
    public static Action<Vector2> SpawnPowerup;
    public static Action GameOver;
}
