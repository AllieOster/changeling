using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
/*
┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━༻🦋༺━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
                                The Camera Manager

    ❤ Start : Set to GlobalView on start 
    ❤ SetCameraActive : Changing the camera 
    ❤ ActivateUI : Activate UI if not Glovalview, Activate colliders if GlobalView

┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━༻⭐️༺━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
*/
public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera globalViewCamera;
    public CinemachineVirtualCamera dormitoryCamera;
    public CinemachineVirtualCamera attickCamera;
    public CinemachineVirtualCamera kitchenCamera;
    public CinemachineVirtualCamera theaterCamera;
    public CinemachineVirtualCamera lobbyCamera;
    public CinemachineVirtualCamera boardCamera;
    
    private CinemachineVirtualCamera activeCamera;

    public GameObject uiElements;
    public GameObject roomColliders;
    public GameObject boardCollider;
    public GameObject itemsLvl1;
    public GameObject itemsLvl2;

    void Start()
    {
        InitializeCamera();
        InitializeScene();
    }

    private void InitializeCamera()
    {
        SetCameraActive(globalViewCamera);
    }
    
    private void InitializeScene()
    {
        uiElements.SetActive(false);
        roomColliders.SetActive(true);
        boardCollider.SetActive(false);
    }

    public void SetCameraActive(CinemachineVirtualCamera cameraToActivate)
    {
        ResetPreviousCamera();

        activeCamera = cameraToActivate;
        activeCamera.Priority = 20;

        HandleUIColliders(cameraToActivate);
        HandleItemsDisplay(LevelManager.CurrentState);
        HandleSpecialCameraSettings();
    }

    private void ResetPreviousCamera()
    {
        if (activeCamera != null)
        {
            activeCamera.Priority = 10;
            uiElements.SetActive(false);
            ResetColliders();
        }
    }

    private void HandleUIColliders(CinemachineVirtualCamera cameraToActivate)
    {
        if (cameraToActivate != globalViewCamera)
        {
            roomColliders.SetActive(false);
            Invoke("ActivateUI", 2f);
        }
        else
        {
            ResetColliders();
        }
    }

    private void ResetColliders()
    {
        roomColliders.SetActive(true);
        boardCollider.SetActive(false);
    }

    private void ActivateUI()
    {
        roomColliders.SetActive(false);
        uiElements.SetActive(true);
    }

    private void HandleItemsDisplay(GameState currentState)
    {
        if (currentState == GameState.Lvl2)
        {
            itemsLvl1.SetActive(false);
        }
        else if (currentState == GameState.Lvl3)
        {
            itemsLvl1.SetActive(false);
            itemsLvl2.SetActive(false);
        }
    }

    private void HandleSpecialCameraSettings()
    {
        if (activeCamera == lobbyCamera)
        {
            boardCollider.SetActive(true);
        }
    }
}