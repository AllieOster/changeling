using UnityEngine;

public class LevelManager: MonoBehaviour
{
    public static GameState CurrentState { get; private set; } 
    public InventoryManager inventoryManager;
    public static void SetGameState(GameState newState)
    {
        CurrentState = newState; 
    }
    public static GameState GetGameState()
    {
        return CurrentState; 
    }

    public void CheckEndLevel(){
        switch(CurrentState){
            case GameState.Lvl1:
                SetGameState(GameState.TransitionLvl2);
                LoadSceneManager.ChangeScene("TransitionOne");
                break;
            case GameState.Lvl2:
                SetGameState(GameState.TransitionLvl3);
                LoadSceneManager.ChangeScene("TransitionTwo");
                break;
            case GameState.Lvl3:
                SetGameState(GameState.Conclusion);
                LoadSceneManager.ChangeScene("Conclusion");
                break;
        }
    }
}