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

        buttonLeft.SetActive(false);
        buttonRight.SetActive(false);
        buttonNextScene.SetActive(false);

        if (activeCamera == cameras[0]) 
        {
            StartActivateButtonsWithDelay(false, true, false, 2f); 
        }
        else if (activeCamera == cameras[7]) 
        {
            StartActivateButtonsWithDelay(true, false, true, 2f); 
        }
        else
        {
            StartActivateButtonsWithDelay(true, true, false, 2f); 
        }
    }
    public void ActivateButtons(bool left, bool right, bool nextscene)
    {
        if (left == true){
            buttonLeft.SetActive(true);
        }
        if (left == false){
            buttonLeft.SetActive(false);
        }
        if (right == true){
            buttonRight.SetActive(true);
        }
        else{
            buttonRight.SetActive(false);
        }
        if (nextscene == true){
            buttonNextScene.SetActive(true);
        }
        else{
            buttonNextScene.SetActive(false);
        }
    }
    private IEnumerator ActivateButtonsCoroutine(bool left, bool right, bool nextscene, float delay)
    {
        yield return new WaitForSeconds(delay);
        ActivateButtons(left, right, nextscene);
    }

    public void StartActivateButtonsWithDelay(bool left, bool right, bool nextscene, float delay)
    {
        StartCoroutine(ActivateButtonsCoroutine(left, right, nextscene, delay));
    }
}