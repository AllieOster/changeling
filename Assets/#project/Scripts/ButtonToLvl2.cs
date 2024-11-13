using UnityEngine;
using UnityEngine.UI;

public class ButtonToLvl2 : MonoBehaviour
{
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        Invoke("LoadLvl2", 1f);
    }
    void LoadLvl2()
    {
        LevelManager.SetGameState(GameState.Lvl2);
        Debug.Log($"State = {LevelManager.CurrentState}");
        LoadSceneManager.ChangeScene("HouseScene");
    }
}