using UnityEngine;
using UnityEngine.UI;

public class ButtonToIntro : MonoBehaviour
{
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        Invoke("LoadIntro", 1f);
    }
    void LoadIntro()
    {
        LevelManager.SetGameState(GameState.Intro);
        Debug.Log($"State = {LevelManager.CurrentState}");
        LoadSceneManager.ChangeScene("Intro");
    }
}