using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dolapInteraktif : MonoBehaviour
{
    [Header("Inner Voice")]
    public AudioClip innerVoiceClip;
    public float innerVoiceTime = 10f;
    public AudioClip cocukCagirdi;

    [Header("Audio Clips")]
    public AudioClip dolapOpenClip;
    public AudioClip dolapCloseClip;

    private bool used = false;

    void OnMouseDown()
    {
        if (used) return;
        used = true;

        CameraManager.Instance.SwitchToThirdPerson();
        StartCoroutine(DolapSequence());
    }

    IEnumerator DolapSequence()
    {
        // Dolap açýlma sesi
        if (dolapOpenClip != null)
            SFXAudioManager.Instance.PlaySFX(dolapOpenClip, 1f);

        // 2 saniye bekle
        yield return new WaitForSeconds(2f);

        //  Ýç ses
        if (innerVoiceClip != null && KarakterIcSesManager.Instance != null)
            KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip, innerVoiceTime);

        // 4 Dolap kapanma sesi
        if (dolapCloseClip != null)
            SFXAudioManager.Instance.PlaySFX(dolapCloseClip, 1f);


        yield return new WaitForSeconds(2f);

        //  Ýç ses
        if (innerVoiceClip != null && KarakterIcSesManager.Instance != null)
            KarakterIcSesManager.Instance.PlayInnerVoice(cocukCagirdi, innerVoiceTime);

        Debug.Log("cocuk çaðýrma tamam");
    }



  
}
