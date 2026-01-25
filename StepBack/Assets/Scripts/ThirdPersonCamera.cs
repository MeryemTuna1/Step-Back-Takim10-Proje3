using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float mouseSensitivity = 3f;
    public float distance;

    float yaw;

    [Header("Outline Raycast")]
    public float maxDistance = 5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                Outline clickedOutline = hit.collider.GetComponent<Outline>();
                if (clickedOutline != null)
                {
                    clickedOutline.OutlineWidth = 0f;
                    clickedOutline.enabled = false;
                }
            }
        }
    }

    void Start()
    {
        yaw = transform.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (!CameraManager.Instance.IsThirdPerson()) return;

        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;

        transform.rotation = Quaternion.Euler(0, yaw, 0);
        transform.position = target.position - transform.forward * distance;
    }



    /*
    public Transform target;
    public float mouseSensitivity = 3f;
    public float distance;

    float yaw;

    [Header("Outline Raycast")]
    public float maxDistance = 5f;

    [Header("Outline Settings")]
    public float hoverOutlineWidth = 6f;

    Outline lastOutline;

    // Týklanmýþ objeler — artýk outline ALMAYACAK
    HashSet<Outline> disabledOutlines = new HashSet<Outline>();

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // TIKLAMA
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                Outline clickedOutline = hit.collider.GetComponent<Outline>();
                if (clickedOutline != null)
                {
                    DisableOutline(clickedOutline);
                }
            }
        }

        // HOVER
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            Outline outline = hit.collider.GetComponent<Outline>();

            if (outline != null && !disabledOutlines.Contains(outline))
            {
                if (lastOutline != outline)
                {
                    ClearLast();

                    lastOutline = outline;
                    outline.enabled = true;
                    outline.OutlineWidth = hoverOutlineWidth;
                }
            }
            else
            {
                ClearLast();
            }
        }
        else
        {
            ClearLast();
        }
    }

    void DisableOutline(Outline outline)
    {
        outline.OutlineWidth = 0f;
        outline.enabled = false;

        disabledOutlines.Add(outline);

        if (lastOutline == outline)
            lastOutline = null;
    }

    void ClearLast()
    {
        if (lastOutline != null)
        {
            lastOutline.OutlineWidth = 0f;
        }

        lastOutline = null;
    }

    void Start()
    {
        yaw = transform.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (!CameraManager.Instance.IsThirdPerson()) return;

        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;

        transform.rotation = Quaternion.Euler(0, yaw, 0);
        transform.position = target.position - transform.forward * distance;
    }
    */

    ////

    /* public Transform target;
     public float mouseSensitivity = 3f;
     public float distance = 4f;
     public float minY = -30f;
     public float maxY = 60f;

     private float yaw;
     private float pitch;

     void Start()
     {
         Cursor.lockState = CursorLockMode.Locked;
     }

     void LateUpdate()
     {
         if (!CameraManager.Instance.IsThirdPerson()) return;

         yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
         pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
         pitch = Mathf.Clamp(pitch, minY, maxY);

         transform.rotation = Quaternion.Euler(pitch, yaw, 0);
         transform.position = target.position - transform.forward * distance;
     }*/
}
