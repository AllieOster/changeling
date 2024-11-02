using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera globalViewCamera;
    public CinemachineVirtualCamera dormitoryCamera;
    public CinemachineVirtualCamera attickCamera;
    public CinemachineVirtualCamera kitchenCamera;
    public CinemachineVirtualCamera theaterCamera;
    public CinemachineVirtualCamera lobbyCamera;
    public GameObject uiElements; 
    public GameObject roomColliders;

    private CinemachineVirtualCamera activeCamera;

    void Start()
    {
        SetCameraActive(globalViewCamera);
        uiElements.SetActive(false); 
        roomColliders.SetActive(true);
    }

    public void SetCameraActive(CinemachineVirtualCamera cameraToActivate)
    {
        if (activeCamera != null)
        {
            activeCamera.Priority = 10; 
            uiElements.SetActive(false); 
            roomColliders.SetActive(true);
        }
        
        activeCamera = cameraToActivate; 
        activeCamera.Priority = 20; 

        if (cameraToActivate != globalViewCamera)
        {
            Invoke("ActivateUI", 2f); 
        }
    }

    private void ActivateUI()
    {
        uiElements.SetActive(true); 
        roomColliders.SetActive(false);
    }
}