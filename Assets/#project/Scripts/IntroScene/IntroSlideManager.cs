using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class IntroSlideManager : MonoBehaviour
{
    [SerializeField] public CinemachineVirtualCamera[] cameras; // 📷
    public CinemachineVirtualCamera activeCamera; // 📷
    public GameObject buttonLeft; // 📌
    public GameObject buttonRight; // 📌
    public GameObject buttonNextScene; // 📌
    public int currentCamera = 0;
    void Awake()
    {
        buttonLeft.SetActive(false); // 📌
        buttonNextScene.SetActive(false); // 📌
        SetCameraActive(cameras[0]); // 📷
        LevelManager.SetGameState(GameState.Intro);
        Debug.Log($"State : {LevelManager.CurrentState}");
    }

    public void SetCameraActive(CinemachineVirtualCamera cameraToActivate)
    {
        if (activeCamera != null) // 📷
        {
            activeCamera.Priority = 10; // 📷
        }      

        activeCamera = cameraToActivate; // 📷
        activeCamera.Priority = 20; // 📷

        if (activeCamera != cameras[0]) // 📷
        {
            Invoke("ActivateLeftButton", 2f); // 📌
        }
        else {
            buttonLeft.SetActive(false);
        }

        if (activeCamera != cameras[7]) // 📷
        {
            Invoke("ActivateRightButton", 2f); // 📌
            buttonNextScene.SetActive(false); // 📌
        }
        else
        {
            Invoke("ActivateLoadNextSceneButton", 2f); // 📌
            buttonRight.SetActive(false); // 📌
        }
    }

    public void ActivateRightButton() // 📌
    {
        buttonRight.SetActive(true); // 📌
    }
    public void ActivateLeftButton() // 📌
    {
        buttonLeft.SetActive(true); // 📌
    }
    public void ActivateLoadNextSceneButton() // 📌
    {
        buttonNextScene.SetActive(true); // 📌
    }
}