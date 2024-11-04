using UnityEngine;
    /*
    ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━༻🦋༺━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
                                    The Room Click Detector

        ❤ Start : Find the camera manager (ask if ok : serialized/public didn't work)
        ❤ OnMouseDown : Check collider clicked and change to the right Camera

    ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━༻⭐️༺━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
    */
public class ZoomRooms : MonoBehaviour
{
    private CameraManager cameraManager;
    void Start()
    {
<<<<<<< HEAD
        cameraManager = FindObjectOfType<CameraManager>(); // ??? 
=======
        cameraManager = FindObjectOfType<CameraManager>(); 
>>>>>>> 860cee4f2d0c783138c1f57eba5170caf38136fb
    }
    void OnMouseDown()
    {
        if (cameraManager != null) 
        {
            switch (gameObject.tag) 
            {
                case "Attick":
                    cameraManager.SetCameraActive(cameraManager.attickCamera);
                    break;
                case "Dormitory":
                    cameraManager.SetCameraActive(cameraManager.dormitoryCamera);
                    break;
                case "Kitchen":
                    cameraManager.SetCameraActive(cameraManager.kitchenCamera);
                    break;
                case "Theater":
                    cameraManager.SetCameraActive(cameraManager.theaterCamera);
                    break;
                case "Lobby":
                    cameraManager.SetCameraActive(cameraManager.lobbyCamera);
                    break;
                default:
                    break;
            }
        }
    }
}