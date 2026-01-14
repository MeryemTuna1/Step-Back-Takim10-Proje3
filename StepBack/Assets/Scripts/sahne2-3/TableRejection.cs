using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableRejection : MonoBehaviour
{
    //yemekhane arkadaþlarý
    public AudioClip innerVoiceClip;
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);

        
    }
}
