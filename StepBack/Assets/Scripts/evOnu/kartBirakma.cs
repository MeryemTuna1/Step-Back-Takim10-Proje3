using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kartBirakma : MonoBehaviour
{
    public GameObject badgeOnNeck, badgeOnNeck1;
    bool taken = false;
    

    public AudioClip innerVoiceClip;

    void OnMouseDown()
    {
        if (taken) return;
        taken = true;

        badgeOnNeck.SetActive(false);      // dolaptaki kart kaybolur
        badgeOnNeck1.SetActive(true);       // boyundaki kart görünür

        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);

        bitisManager.Instance.FadeToBlack();
    }
}
