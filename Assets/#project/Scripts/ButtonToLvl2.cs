using System.Collections;
using System.Collections.Generic;
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
        Invoke("LoadLvl2", 2f);
    }
    void LoadLvl2() // load dans lvl manager ??? 
    {
        LevelManager.SetGameState(GameState.Lvl2);
        Debug.Log($"State = {LevelManager.CurrentState}");
        LoadSceneManager.ChangeScene("HouseScene");
    }
}