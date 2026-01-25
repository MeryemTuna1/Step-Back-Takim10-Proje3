using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [Header("Cameras")]
    public Camera firstPersonCam;
    public Camera thirdPersonCam;
    public Camera topDownCam;

    [Header("Roots & Targets")]
    public Transform playerTarget;       // Player
    public Transform thirdPersonPivot;   // pivot3RD
    public Transform cameraRoot;         // CameraRoot12 (ROOT'ta)

    [Header("Third Person Offset")]
    public Vector3 thirdPersonOffset = new Vector3(0f, 1.5f, -3f);

    [Header("Top Down Offset")]
    public Vector3 topDownOffset = new Vector3(0f, 10f, 0f);

    [Header("Wall Collision")]
    public LayerMask wallLayer;
    public float collisionPadding=0.3f;

    [Header("Camera Collision")]
    public float cameraRadius=0.5f;

    private Camera activeCam;

    // Look system
    Transform lookTarget;
    bool looking = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        SwitchToFirstPerson();
    }

    void LateUpdate()
    {
        if (activeCam == null || playerTarget == null) return;

        // ROOT sadece 3RD ve TOPDOWN için takip etsin
        if (cameraRoot != null && !IsFirstPerson())
        {
            cameraRoot.position = playerTarget.position;
            cameraRoot.rotation = playerTarget.rotation;
        }

        // LOOK SYSTEM
        if (looking && lookTarget != null)
            activeCam.transform.LookAt(lookTarget);

        // ===== THIRD PERSON + STRONG WALL COLLISION =====
        if (activeCam == thirdPersonCam && thirdPersonPivot != null)
        {
            Vector3 desiredWorldPos =
                cameraRoot.position +
                playerTarget.rotation * thirdPersonOffset;

            Vector3 pivotPos = thirdPersonPivot.position;
            Vector3 dir = (desiredWorldPos - pivotPos).normalized;
            float dist = Vector3.Distance(pivotPos, desiredWorldPos);

            if (Physics.SphereCast(
                pivotPos,
                cameraRadius,
                dir,
                out RaycastHit hit,
                dist,
                wallLayer,
                QueryTriggerInteraction.Ignore))
            {
                activeCam.transform.position =
                    hit.point - dir * (cameraRadius + collisionPadding);
            }
            else
            {
                activeCam.transform.position = desiredWorldPos;
            }

            activeCam.transform.LookAt(thirdPersonPivot.position);
        }

        // ===== TOP DOWN =====
        if (activeCam == topDownCam)
        {
            activeCam.transform.position = cameraRoot.position + topDownOffset;
            activeCam.transform.rotation =
                Quaternion.Euler(90f, playerTarget.eulerAngles.y, 0f);
        }

        // ===== FPS =====
        if (activeCam == firstPersonCam)
        {
            // FPS'e dokunma — Head/MouseLook yönetsin
            return;
        }
    }

    // ===== Camera Switching =====
    public void SwitchToFirstPerson()
    {
        SetActiveCamera(firstPersonCam);
    }

    public void SwitchToThirdPerson()
    {
        SetActiveCamera(thirdPersonCam);
    }

    public void SwitchToTopDown()
    {
        SetActiveCamera(topDownCam);
    }

    void SetActiveCamera(Camera cam)
    {
        firstPersonCam.gameObject.SetActive(false);
        thirdPersonCam.gameObject.SetActive(false);
        topDownCam.gameObject.SetActive(false);

        cam.gameObject.SetActive(true);
        activeCam = cam;
    }

    // ===== Look System =====
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

    // ===== Helpers =====
    public Camera GetActiveCamera() => activeCam;
    public bool IsThirdPerson() => activeCam == thirdPersonCam;
    public bool IsFirstPerson() => activeCam == firstPersonCam;
    public bool IsTopDown() => activeCam == topDownCam;



    /*
    public static CameraManager Instance;

    public Camera thirdPersonCam;
    public Camera firstPersonCam;
    public Camera topDownCam;

    public Transform cameraYawRoot;

    Camera activeCam;

    //
    [Header("Third Person Collision")]
    public Transform playerTarget;     // player (kamera baktýðý yer)
    public float thirdPersonDistance;
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
    }*/
    /*
        void LateUpdate()
        {
            if (!looking || lookTarget == null || activeCam == null) return;

            activeCam.transform.LookAt(lookTarget);
        }*/
}
