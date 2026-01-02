using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateCarry : MonoBehaviour
{
    public Transform carryPoint;

    public GameObject carriedPlate;
    public dropZone currentZone;

    void Update()
    {
        if (!CameraManager.Instance.IsThirdPerson()) return;

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (carriedPlate == null)
                TryPickPlate();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (carriedPlate != null)
                TryDropPlate();
        }
    }

    void TryPickPlate()
    {
        Camera cam = CameraManager.Instance.GetActiveCamera();
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        if (Physics.Raycast(ray, out RaycastHit hit, 2f))
        {
            if (hit.transform.CompareTag("Plate"))
            {
                carriedPlate = hit.transform.gameObject;

                carriedPlate.transform.SetParent(carryPoint);
                carriedPlate.transform.localPosition = Vector3.zero;
                carriedPlate.transform.localRotation = Quaternion.identity;

                KarakterIcSesManager.Instance.ShowText("Bunlarý tezgâha býrakmalýyým.");
            }
        }
    }

    void TryDropPlate()
    {
        if (currentZone == null)
        {
            KarakterIcSesManager.Instance.ShowText("Buraya býrakamam.");
            return;
        }

        carriedPlate.transform.SetParent(null);
        carriedPlate.transform.position = currentZone.snapPoint.position;
        carriedPlate.transform.rotation = currentZone.snapPoint.rotation;

        carriedPlate = null;
        currentZone = null;

        KarakterIcSesManager.Instance.ShowText("Tamam.");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out dropZone zone))
            currentZone = zone;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out dropZone zone))
        {
            if (zone == currentZone)
                currentZone = null;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, 3f);
    }
}
