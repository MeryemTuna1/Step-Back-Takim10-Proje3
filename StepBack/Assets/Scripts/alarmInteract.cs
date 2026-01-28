using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarmInteract : MonoBehaviour
{
    // public AudioSource alarmSource;
    public AudioClip innerVoiceClip;
    public wakeUpManager manager;

    public bool alarm = false;

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
                    manager.StopAlarm();
                    CameraManager.Instance.SwitchToFirstPerson();
                    KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip, 5f);
                    alarm = true;
                   // Destroy(this);
                }
            }
        }
    }

}
