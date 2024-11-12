using UnityEngine;
using UnityEngine.UI;

public class ButtonToIntro : MonoBehaviour
{
    public GameData gameData; 

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        gameData.collectedItems.Clear();
    }

    void OnButtonClick()
    {
        Invoke("LoadIntro", 1f);
    }
    void LoadIntro()
    {
        LevelManager.SetGameState(GameState.Intro);
        Debug.Log($"State = {LevelManager.CurrentState}");
        LoadSceneManager.ChangeScene("Intro", gameData);
    }
}