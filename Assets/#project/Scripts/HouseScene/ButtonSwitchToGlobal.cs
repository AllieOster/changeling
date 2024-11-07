using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitchToGlobal : MonoBehaviour
{
    [SerializeField]private CameraManager cameraManager; 
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }
    public void OnButtonClick()
    {
        if (cameraManager != null)
        {
            cameraManager.SetCameraActive(cameraManager.globalViewCamera);
        }
        else{
            Debug.LogError("You need to link a CameraManager to this script.");
        }
    }
}