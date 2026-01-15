using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desk : MonoBehaviour
{
    bool used = false;

    public AudioClip innerVoiceClip;
    public AudioClip keyboardClip;

    public Animator playerAnim;

    //public float sitAnimTime = 1.5f;
   // public float workTime = 3f;

    AudioSource keyboardLoopSource;

    void OnTriggerEnter(Collider other)
    {
        if (used) return;
        if (!other.CompareTag("desk")) return;

        used = true;
        StartCoroutine(DeskSequence());
    }

    IEnumerator DeskSequence()
    {
        // Kamera FPS
        CameraManager.Instance.SwitchToFirstPerson();

        // OTURMA ANÝMÝ
        playerAnim.SetTrigger("SitDown");
        yield return new WaitForSeconds(2f);

        // ÇALIÞMA ANÝMÝ
        playerAnim.SetBool("Working", true);

        // KLAVYE SESÝ (LOOP)
        keyboardLoopSource =
            SFXAudioManager.Instance.PlayLoopSFX(keyboardClip, 10f);

        // ÝÇ SES
        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);

        yield return new WaitForSeconds(5f);

        // ÇALIÞMA BÝTÝÞ
        playerAnim.SetBool("Working", false);

        // KLAVYE SESÝ DURDUR
        SFXAudioManager.Instance.StopLoopSFX(keyboardLoopSource);


        yield return new WaitForSeconds(1f);

        // CANAVAR SEANSI
        FindObjectOfType<OfficeMonsterSequence>().StartSequence();
    }


    /* bool used = false;
     public AudioClip innerVoiceClip, innerVoiceClip1;
     void OnTriggerEnter(Collider other)
     {
         if (used) return;
         if (!other.CompareTag("desk")) return;

         used = true;

         // Kamera FPS
         CameraManager.Instance.SwitchToFirstPerson();

         // Ýç ses
         KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);

         // Masada oturma hissi için hareketi kilitlemek istersen:
         // other.GetComponent<PlayerMovement>().enabled = false;

         // Canavar sekansýný baþlat
         FindObjectOfType<OfficeMonsterSequence>().StartSequence();

         KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip1);
     }*/
}
