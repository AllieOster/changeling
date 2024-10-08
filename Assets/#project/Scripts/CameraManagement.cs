using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
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

    void OnMouseDown()
    {
        // Assurez-vous que ce script est attaché aux colliders correspondants
        Debug.Log("Hit: " + gameObject.tag);
        
        switch (gameObject.tag)
        {
            case "Attick":
                SetCameraActive(attickCamera);
                break;
            case "Bedroom":
                SetCameraActive(dormitoryCamera);
                break;
            case "Kitchen":
                SetCameraActive(kitchenCamera);
                break;
            case "Theater":
                SetCameraActive(theaterCamera);
                break;
            case "Lobby":
                SetCameraActive(lobbyCamera);
                break;
            default:
                Debug.Log("No camera match found for this tag.");
                break;
        }
    }

    void Update()
    {
        // Pour revenir à la GlobalView avec un défilement de la molette de la souris
        if (Input.mouseScrollDelta.y < 0)
        {
            SetCameraActive(globalViewCamera);
        }
    }

    void SetCameraActive(CinemachineVirtualCamera cameraToActivate)
    {
        if (activeCamera != null)
            activeCamera.Priority = 10; // Réinitialiser la priorité des caméras non actives

        activeCamera = cameraToActivate;
        activeCamera.Priority = 20; // Définir une priorité plus élevée pour la caméra active
    }
}