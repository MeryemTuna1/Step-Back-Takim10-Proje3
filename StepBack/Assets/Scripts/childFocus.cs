using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childFocus : MonoBehaviour
{
    public Transform focusPoint;
    bool done = false;

    void OnMouseDown()
    {
        if (done) return;
        done = true;

        StartCoroutine(FocusRoutine());
    }

    IEnumerator FocusRoutine()
    {
        // FPS kameraya geç
        CameraManager.Instance.SwitchToFirstPerson();

        Camera cam = CameraManager.Instance.GetActiveCamera();

        float t = 0f;
        while (t < 2.5f)
        {
            cam.transform.LookAt(focusPoint);
            t += Time.deltaTime;
            yield return null;
        }

        KarakterIcSesManager.Instance.ShowText(
            "Bu dünyada en önemli þey sensin."
        );

        yield return new WaitForSeconds(1.5f);

        CameraManager.Instance.SwitchToThirdPerson();
    }
}
