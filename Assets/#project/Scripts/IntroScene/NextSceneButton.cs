using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextSceneButton : MonoBehaviour
{
    public LoadSceneManager loadSceneManager;
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }
    void OnButtonClick()
    {
        Invoke("LoadLvl1", 2f);
    }

    void LoadLvl1()
    {
        LevelManager.SetGameState(GameState.Lvl1);
        Debug.Log($"State = {LevelManager.CurrentState}");
        loadSceneManager.ChangeScene("HouseScene");
    }
}