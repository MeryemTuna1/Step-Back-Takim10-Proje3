using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yakaKarti : MonoBehaviour
{
    public GameObject badgeOnNeck;
    bool taken = false;
    
    public AudioClip innerVoiceClip;
    void OnMouseDown()
    {
        if (taken) return;
        taken = true;

        gameObject.SetActive(false);      // dolaptaki kart kaybolur
        badgeOnNeck.SetActive(true);       // boyundaki kart görünür

        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);
    }
}
