using System;

//Gets Reports and Broadcasts them
public static class GameEvents
{
    //GameStates
    public static event Action OnStart = null;
    public static event Action OnPlaying = null;
    public static event Action OnPause = null;
    public static event Action OnGameOver = null;
    //Enemy
    public static event Action<Enemy> OnEnemyDied = null;
    //Timer related stuff
    public static event Action OnCorruptionStart = null;
    public static event Action OnCorruptionStop = null;
    public static event Action OnCorrupted = null;
    //Player
    public static event Action<Player> OnPlayerDied = null;

    //functions reported to by the scripts
    //GameStates
    public static void ReportGameStart()
    {
        OnStart?.Invoke();
    }
    public static void ReportGamePlaying()
    {
        OnPlaying?.Invoke();
    }
    public static void ReportGamePause()
    {
        OnPause?.Invoke();
    }
    public static void ReportGameOver()
    {
        OnGameOver?.Invoke();
    }
    //Enemy Status
    public static void ReportEnemyDied(Enemy _enemy)
    {
        OnEnemyDied?.Invoke(_enemy);
    }
    //Death Timer
    public static void ReportCorrupted()
    {
        OnCorrupted?.Invoke();
    }
    public static void ReportCorruptionStart()
    {
        OnCorruptionStart?.Invoke();
    }
    public static void ReportCorruptionStop()
    {
        OnCorruptionStop?.Invoke();
    }
    //Player Status
    public static void ReportPlayerDied(Player _player)
    {
        OnPlayerDied?.Invoke(_player);
    }

}