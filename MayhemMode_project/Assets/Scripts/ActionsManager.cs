using System;

public static class ActionsManager
{
    public static Action<float> OnCharacterMultiplierStatsChanged;
    
#region Actions/Events
    public static Action<int> onHealthChanged;
    public static Action<int> onExpChanged;
    public static Action<int> onKillCountChanged;
    public static Action onEnemyDied;

#endregion
}
