using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yakaKarti : MonoBehaviour
{
    public GameObject badgeOnNeck;
    bool taken = false;
    public Animator animator;
    public AudioClip innerVoiceClip;

    public plateCarry isO;
    void OnMouseDown()
    {
        if (taken) return;

        // ---- ÞART: isO true deðilse ALAMAZ ----
        if (isO == null || !isO.isOk)
        {
            Debug.Log("Yaka kartý için þart saðlanmadý!");
            return;
        }

        taken = true;

        gameObject.SetActive(false);
        badgeOnNeck.SetActive(true);

        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);
        animator.SetTrigger("yaka");
    }

    
}
