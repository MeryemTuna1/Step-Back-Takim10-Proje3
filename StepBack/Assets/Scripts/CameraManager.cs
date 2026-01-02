using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    public Camera thirdPersonCam;
    public Camera firstPersonCam;
    public Camera topDownCam;

    public Transform cameraYawRoot;

    Camera activeCam;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        SwitchToFirstPerson();
    }

    public void SwitchToThirdPerson()
    {
        SetActiveCamera(thirdPersonCam);
    }

    public void SwitchToFirstPerson()
    {
        SetActiveCamera(firstPersonCam);
    }

    public void SwitchToTopDown()
    {
        SetActiveCamera(topDownCam);
    }

    void SetActiveCamera(Camera cam)
    {
        thirdPersonCam.gameObject.SetActive(false);
        firstPersonCam.gameObject.SetActive(false);
        topDownCam.gameObject.SetActive(false);

        cam.gameObject.SetActive(true);
        activeCam = cam;
    }

    //  HATA VEREN FONKSÝYON BURASIYDI
    public Camera GetActiveCamera()
    {
        return activeCam;
    }

    // Ýstersen kontrol için
    public bool IsThirdPerson()
    {
        return activeCam == thirdPersonCam;
    }
    public bool IsFirstPerson()
    {
        return activeCam == firstPersonCam;
    }
    public bool IsTopDown()
    {
        return activeCam == topDownCam;
    }
}
