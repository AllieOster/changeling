using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLeft : MonoBehaviour
{
    [SerializeField] public IntroSlideManager introslide; 
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }
    public void OnButtonClick()
    {
        if (introslide != null)
        {
            introslide.buttonLeft.SetActive(false);
            introslide.buttonRight.SetActive(false);
            if (introslide.currentCamera != 0)
            {
                introslide.currentCamera--;
                introslide.SetCameraActive(introslide.cameras[introslide.currentCamera]);
            }
        }
        else
        {
            Debug.LogError("Vous devez lier un IntroSlideManager à ce script.");
        }
    }
}