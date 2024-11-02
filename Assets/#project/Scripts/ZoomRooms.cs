using UnityEngine;

public class RoomClickDetector : MonoBehaviour
{
    private CameraManager cameraManager;

    void Start()
    {
        cameraManager = FindObjectOfType<CameraManager>();
    }

    void OnMouseDown()
    {
        if (cameraManager != null)
        {
            Debug.Log("Clické sur " + gameObject.name + " avec le tag " + gameObject.tag);

            if (CompareTag("Attick"))
            {
                cameraManager.SetCameraActive(cameraManager.attickCamera);
            }
            else if (CompareTag("Dormitory"))
            {
                cameraManager.SetCameraActive(cameraManager.dormitoryCamera);
            }
            else if (CompareTag("Kitchen"))
            {
                cameraManager.SetCameraActive(cameraManager.kitchenCamera);
            }
            else if (CompareTag("Theater"))
            {
                cameraManager.SetCameraActive(cameraManager.theaterCamera);
            }
            else if (CompareTag("Lobby"))
            {
                cameraManager.SetCameraActive(cameraManager.lobbyCamera);
            }
        }
    }
}