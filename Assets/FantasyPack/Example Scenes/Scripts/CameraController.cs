using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera; // Assign this in the inspector
    public Camera[] otherCameras; // Assign any other cameras you might want to deactivate

    void Start()
    {
        // Enable the main camera
        mainCamera.gameObject.SetActive(true);
        
        // Disable all other cameras
        foreach (Camera cam in otherCameras)
        {
            cam.gameObject.SetActive(false);
        }
    }
}
