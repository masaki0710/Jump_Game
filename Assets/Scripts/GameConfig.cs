public static class GameConfig
{
    // プレイヤーの設定
    public const float DefaultPlayerMoveSpeed = 8.0f;
    public const float MinJumpForce = 5.0f;
    public const float MaxJumpForce = 10.0f;
    public const float JumpChargeSpeed = 2.0f;

    // 障害物の設定
    public const float PlatformMoveSpeed = 3.0f;
    public const float ObstacleFloorLength = 15f;
    public const float ObstacleFloorWidth = 8f;
    public const float SpawnInterval = ObstacleFloorLength / PlatformMoveSpeed;

    // ゲームオーバーの設定
    public const float DeathYThreshold = -5.0f;
    public const float DeathXThreshold = -15.0f;

    // ゲームオーバー演出の設定
    public const float GameOverDelay = 2.0f;
    public const float SlowMotionScale = 0.3f;
}