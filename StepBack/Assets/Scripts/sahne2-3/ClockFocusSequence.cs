using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockFocusSequence : MonoBehaviour
{
    public Transform cameraFocusPoint;
    public float moveTime = 1.5f;

    bool used = false;

    void OnMouseDown()
    {
        if (used) return;
        used = true;

        StartCoroutine(FocusClock());
    }

    IEnumerator FocusClock()
    {
        // FPS’e geç
        CameraManager.Instance.SwitchToFirstPerson();

        yield return new WaitForEndOfFrame();

        Camera cam = CameraManager.Instance.GetActiveCamera();

        Vector3 startPos = cam.transform.position;
        Quaternion startRot = cam.transform.rotation;

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / moveTime;

            cam.transform.position = Vector3.Lerp(startPos, cameraFocusPoint.position, t);
            cam.transform.rotation = Quaternion.Slerp(startRot, cameraFocusPoint.rotation, t);

            yield return null;
        }

        KarakterIcSesManager.Instance.ShowText("Kimse söylemedi.");
        yield return new WaitForSeconds(1.2f);
        KarakterIcSesManager.Instance.ShowText("Herkes gitmiþ.");
        yield return new WaitForSeconds(0.5f);
        CameraManager.Instance.SwitchToThirdPerson();
    }
}
