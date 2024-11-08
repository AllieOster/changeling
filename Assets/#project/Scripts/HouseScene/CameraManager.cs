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
    public CinemachineVirtualCamera globalViewCamera; // 📷
    public CinemachineVirtualCamera dormitoryCamera;  // 📷
    public CinemachineVirtualCamera attickCamera; // 📷
    public CinemachineVirtualCamera kitchenCamera; // 📷
    public CinemachineVirtualCamera theaterCamera; // 📷
    public CinemachineVirtualCamera lobbyCamera; // 📷
    public CinemachineVirtualCamera boardCamera; // 📷
    private CinemachineVirtualCamera activeCamera; // 📷
    public GameObject uiElements; // 📌
    public GameObject roomColliders; // 🔍
    public GameObject boardCollider; // 🔍
    void Start()
    {
        SetCameraActive(globalViewCamera); // 📷
        uiElements.SetActive(false); // 📌
        roomColliders.SetActive(true); // 🔍
        boardCollider.SetActive(false); // 🔍
    }
    public void SetCameraActive(CinemachineVirtualCamera cameraToActivate)
    {
        if (activeCamera != null)
        {
            activeCamera.Priority = 10; // 📷
            uiElements.SetActive(false); // 📌
            roomColliders.SetActive(true); // 🔍
            boardCollider.SetActive(false); // 🔍
        }

        activeCamera = cameraToActivate; // 📷
        activeCamera.Priority = 20; // 📷

        if (cameraToActivate != globalViewCamera) // 📷
        {
            Invoke("ActivateUI", 2f); // 🔍
        }
        if(activeCamera == lobbyCamera) // 📷
        {
            boardCollider.SetActive(true); // 🔍
        }
    }
    private void ActivateUI()
    {
        uiElements.SetActive(true); // 📌
        roomColliders.SetActive(false); // 🔍
        // 🌿🌿🌿 TODO : animation UI -> coroutine-scale or animator ?! 🌿🌿🌿
    }
}