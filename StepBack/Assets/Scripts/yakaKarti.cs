using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yakaKarti : MonoBehaviour
{
    [Header("Visual")]
    public GameObject badgeOnNeck;   // boyundaki kart

    [Header("State")]
    public bool taken = false;

    [Header("References")]
    public Animator animator;
    public AudioClip innerVoiceClip;

    [Header("Conditions")]
    public plateCarry isO;   // þart scripti

    void OnMouseDown()
    {
        // Zaten alýndýysa
        if (taken) return;

        // Þart saðlanmadýysa alamaz
        if (isO != null && !isO.isOk)
        {
            Debug.Log("Þart saðlanmadý, yaka kartý alýnamaz!");
            return;
        }

        taken = true;

        // Dolaptaki kart kaybolur
        gameObject.SetActive(false);

        // Boyundaki kart görünür
        if (badgeOnNeck != null)
            badgeOnNeck.SetActive(true);

        // Ýç ses
        if (innerVoiceClip != null && KarakterIcSesManager.Instance != null)
            KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);

        // Animasyon
        if (animator != null)
            animator.SetTrigger("yaka");

        Debug.Log("Yaka kartý alýndý");
    }
}
