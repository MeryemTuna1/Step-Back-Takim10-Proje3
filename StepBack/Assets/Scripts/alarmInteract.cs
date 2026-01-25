using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarmInteract : MonoBehaviour
{
    public AudioClip innerVoiceClip;
    public wakeUpManager manager;

    void Update()
    {
        if (!CameraManager.Instance.IsFirstPerson()) return;

        if (Input.GetMouseButtonDown(0))
        {
            Camera cam = CameraManager.Instance.GetActiveCamera();
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red, 2f);

            if (Physics.Raycast(ray, out RaycastHit hit, 5f))
            {
                Debug.Log("Hit: " + hit.transform.name);

                if (hit.transform == transform)
                {
                    Debug.Log("ALARM TIKLANDI!");

                    manager.StopAlarm();
                    CameraManager.Instance.SwitchToFirstPerson();
                    KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip, 5f);

                    Destroy(this);
                }
            }
            else
            {
                Debug.Log("Raycast hiçbir þeye çarpmadý");
            }
        }
    }

}
