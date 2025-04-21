using System;

public static class PlayerActions
{
    public static Action OnPlayerJump;

    public static Action OnPlayerMoveLeft;

    public static Action OnPlayerMoveRight;

    public static Action OnPlayerMovementBoost;

    public static Action OnPlayerGrouded;

    public static Action PlayerJumping;

    public static Action OnPlayerShoot;

    public static string GroundTag = "Platform";

    public static string PlayerTag = "Player";

    public static string EnemyTag = "Enemy";
    
    public static string EchoTag = "Echo";

    public static Action<float> OnPlayerEnergyChanged;

    public static Action OnPlayerTouchCrystal;
}
