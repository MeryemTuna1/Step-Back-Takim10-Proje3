using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesaj1 : MonoBehaviour
{

    public AudioClip innerVoiceClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            CameraManager.Instance.SwitchToFirstPerson();

            KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip, 10f);
        }
    }
}
