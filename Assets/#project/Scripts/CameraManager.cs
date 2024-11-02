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

    private CinemachineVirtualCamera activeCamera;

    void Start()
    {
        SetCameraActive(globalViewCamera);
    }

    public void SetCameraActive(CinemachineVirtualCamera cameraToActivate)
    {
        if (activeCamera != null)
            activeCamera.Priority = 10; 

        activeCamera = cameraToActivate; 
        activeCamera.Priority = 20; 
    }
}
