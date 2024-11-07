using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRight : MonoBehaviour
{
    [SerializeField] public IntroSlideManager introslide; 
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        Debug.Log(introslide != null ? "IntroSlideManager est assigné." : "IntroSlideManager est null.");

    }
    public void OnButtonClick()
    {
        if (introslide != null)
        {
            Debug.Log("IntroSlideManager est actif.");
            if (introslide.currentCamera != 7)
            {
                introslide.currentCamera++;
                introslide.SetCameraActive(introslide.cameras[introslide.currentCamera]);
            }
        }
        else
        {
            Debug.LogError("Vous devez lier un IntroSlideManager à ce script.");
        }
    }
}
