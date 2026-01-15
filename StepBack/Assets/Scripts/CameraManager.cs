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

    //
    [Header("Third Person Collision")]
    public Transform playerTarget;     // player (kamera baktýðý yer)
    public float thirdPersonDistance = 4f;
    public LayerMask wallLayer;
    float initialCamY;
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

    void LateUpdate()
    {
        if (activeCam == null) return;

        if (looking && lookTarget != null)
            activeCam.transform.LookAt(lookTarget);

        if (IsThirdPerson() && playerTarget != null)
        {
            Vector3 dir = (activeCam.transform.position - playerTarget.position).normalized;

            if (Physics.Raycast(playerTarget.position, dir, out RaycastHit hit, thirdPersonDistance, wallLayer))
                activeCam.transform.position = hit.point - dir * 0.3f;
            else
                activeCam.transform.position = playerTarget.position + dir * thirdPersonDistance;
        }

        // Y sabitleme (HER ZAMAN EN SON)
        Vector3 pos = activeCam.transform.position;
        pos.y = initialCamY;
        activeCam.transform.position = pos;
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


       // Kameranýn PLAY ÖNCESÝ Y DEÐERÝNÝ KAYDET
        initialCamY = cam.transform.position.y;
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


    // === INVITATION / LOOK SYSTEM ===
    Transform lookTarget;
    bool looking = false;

    public void LookAtTarget(Transform target)
    {
        lookTarget = target;
        looking = true;
    }

    public void StopLookAt()
    {
        looking = false;
        lookTarget = null;
    }
/*
    void LateUpdate()
    {
        if (!looking || lookTarget == null || activeCam == null) return;

        activeCam.transform.LookAt(lookTarget);
    }*/
}
