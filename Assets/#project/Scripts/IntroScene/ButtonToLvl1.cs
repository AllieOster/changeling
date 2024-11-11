using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToLvl1 : MonoBehaviour
{
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }
    void OnButtonClick()
    {
        Invoke("LoadLvl1", 2f);
    }
    void LoadLvl1() // load dans lvl manager ??? 
    {
        LevelManager.SetGameState(GameState.Lvl1);
        Debug.Log($"State = {LevelManager.CurrentState}");
        LoadSceneManager.ChangeScene("HouseScene");
    }
}