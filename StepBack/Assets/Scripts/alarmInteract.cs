using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarmInteract : MonoBehaviour
{
   // public AudioSource alarmSource;

    void Update()
    {
        if (!CameraManager.Instance.IsFirstPerson()) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = CameraManager.Instance
                .GetActiveCamera()
                .ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                   // alarmSource.Stop();
                    CameraManager.Instance.SwitchToThirdPerson();
                    KarakterIcSesManager.Instance.ShowText("Yine mi? Sadece birkaç saat daha bu sýcak yorganýn altýnda kalabilseydim...");
                    Destroy(this);
                }
            }
        }
    }
}
