using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonCamera : MonoBehaviour
{
    public float maxDistance = 5f;
    public LayerMask interactLayer;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red, 1f);

            if  (Physics.Raycast(ray, out hit, maxDistance, interactLayer))
            {
                Debug.Log("Raycast hit: " + hit.collider.name);

                // Parent + Child her yerde ara (GARANTÝ)
                Outline[] outlines = hit.collider.GetComponentsInParent<Outline>(true);

                if (outlines.Length == 0)
                {
                    outlines = hit.collider.GetComponentsInChildren<Outline>(true);
                }

                Debug.Log("Bulunan Outline sayýsý: " + outlines.Length);

                foreach (Outline o in outlines)
                {
                    Debug.Log("Outline kapatýldý: " + o.gameObject.name);
                    o.OutlineWidth = 0f;
                }
            }
            else
            {
                Debug.Log("Raycast hiçbir þeye çarpmadý!");
            }
        }
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
