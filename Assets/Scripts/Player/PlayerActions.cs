using System;

public static class PlayerActions
{
    public static Action OnPlayerJump;

    public static Action OnPlayerMoveLeft;

    public static Action OnPlayerMoveRight;

    public static Action OnPlayerMovementBoost;

    public static Action OnPlayerGrouded;

    public static Action PlayerJumping;

    public static string GroundTag = "Ground";

    public static string PlayerTag = "Player";
}
