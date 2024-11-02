using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitchToGlobal : MonoBehaviour
{
    public CameraManager cameraManager; // why the hell Serialized won't work ?! 
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        if (cameraManager != null) // I've seen this like EVERYWHERE but is this really necessary ?! 
        {
            cameraManager.SetCameraActive(cameraManager.globalViewCamera);
        }
    }
}