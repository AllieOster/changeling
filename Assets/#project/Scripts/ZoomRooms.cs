using UnityEngine;

    /*
    ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━༻🦋༺━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
                                    The Room Click Detector

        ❤ Start : Find the camera manager (ask if ok : serialized/public didn't work)
        ❤ OnMouseDown : Check collider clicked and change to the right Camera

    ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━༻⭐️༺━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
    */

public class RoomClickDetector : MonoBehaviour
{
    private CameraManager cameraManager;
    void Start()
    {
        cameraManager = FindObjectOfType<CameraManager>(); // ??? 
    }

    void OnMouseDown() // why couln't I make a switch there ?! 
    {
        if (cameraManager != null)
        {
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