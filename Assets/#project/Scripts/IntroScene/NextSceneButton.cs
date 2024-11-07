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
        Invoke("LoadNextScene", 2f);
    }

    void LoadNextScene(){
        loadSceneManager.ChangeScene("HouseScene");
    }
}