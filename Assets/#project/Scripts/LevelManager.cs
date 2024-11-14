using UnityEngine;

public static class LevelManager
{
    public static GameState CurrentState { get; private set; } 
    public static void SetGameState(GameState newState)
    {
        CurrentState = newState; 
    }
    public static GameState GetGameState()
    {
        return CurrentState; 
    }
}