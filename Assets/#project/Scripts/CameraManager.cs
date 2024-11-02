using UnityEngine;
using Cinemachine;

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
    /*
    ┏━━━━━━━━━━━༻🦋༺━━━━━━━━━━━━┓
       References to the Cameras 
    ┗━━━━━━━━━━━༻⭐️༺━━━━━━━━━━━━┛
     */
    public CinemachineVirtualCamera globalViewCamera; // public parce qu'en SerializeField il refusait d'accéder aux cameras ; demander pourquoi.
    public CinemachineVirtualCamera dormitoryCamera;
    public CinemachineVirtualCamera attickCamera;
    public CinemachineVirtualCamera kitchenCamera;
    public CinemachineVirtualCamera theaterCamera;
    public CinemachineVirtualCamera lobbyCamera;
    private CinemachineVirtualCamera activeCamera;
    /*
    ┏━━━━━━━━━━━━━━༻🦋༺━━━━━━━━━━━━━━━┓
        Reference to the UI elements, 
        so they can appear and disapear
        based on which camera is active 
    ┗━━━━━━━━━━━━━━༻⭐️༺━━━━━━━━━━━━━━━┛
     */
    public GameObject uiElements; 
    /*
    ┏━━━━━━━━━━━━━━━━━༻🦋༺━━━━━━━━━━━━━━━━━┓
        Reference to the colliders so 
        they can be activated on globalview 
        but not on another camera
    ┗━━━━━━━━━━━━━━━━━༻⭐️༺━━━━━━━━━━━━━━━━━┛
    */
    public GameObject roomColliders;
    /*
    ┏━━━━━━━━━━━━━━━━━༻🦋༺━━━━━━━━━━━━━━━━━┓
        Start : 
        ❤ Set GlobalView
        ❤ Hide UI
        ❤ Activate colliders on rooms
    ┗━━━━━━━━━━━━━━━━━༻⭐️༺━━━━━━━━━━━━━━━━━┛
    */
    void Start()
    {
        SetCameraActive(globalViewCamera);
        uiElements.SetActive(false); 
        roomColliders.SetActive(true);
    }
    /*
    ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━༻🦋༺━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
        SetCameraActive : 
        ❤ ((If)) there is an active Camera, change its priority so another 
        one can take control, hide UI, activate colliders.
        ❤ Change camera by giving the chosen camera a higher priority
        ❤ Invoke : ((If)) camera is not globalView, UI appearing after 2 sec, 
        (might change for a coroutine - animation incoming)
    ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━༻⭐️༺━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
    */
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
    /*
    ┏━━━━━━━━━━━━━༻🦋༺━━━━━━━━━━━━━┓
        ActivateUI : 
        ❤ Activate UI
        ❤ DeActivate Room Colliders 
    ┗━━━━━━━━━━━━━༻⭐️༺━━━━━━━━━━━━━┛
    */
    private void ActivateUI()
    {
        uiElements.SetActive(true); 
        roomColliders.SetActive(false);
        // 🌿🌿🌿 TODO : animation UI -> coroutine-scale or animator ?! 🌿🌿🌿
    }
}