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

    [Header("Dolap Kapak Pivot")]
    public Transform kapakPivot;
    public float openAngle = 90f;
    public float closeAngle = 0f;
    public float rotateSpeed = 120f;

    private bool kapakAcik = false;
    private bool kapakHareket = false;

    private bool used = false;
    public bool opern = false;


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

        // ---- KAPAK AÇ (ROTASYON) ----
        if (!kapakHareket && kapakPivot != null)
        {
            StartCoroutine(RotateKapak(true));
        }

        // 2 saniye bekle
        yield return new WaitForSeconds(2f);

        //  Ýç ses
        if (innerVoiceClip != null && KarakterIcSesManager.Instance != null)
            KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip, innerVoiceTime);

        // ---- KAPAK KAPAT (ROTASYON) ----
        if (!kapakHareket && kapakPivot != null)
        {
            StartCoroutine(RotateKapak(false));
        }

        // 4 Dolap kapanma sesi
        if (dolapCloseClip != null)
            SFXAudioManager.Instance.PlaySFX(dolapCloseClip, 1f);


        yield return new WaitForSeconds(2f);

        //  Ýç ses
        if (innerVoiceClip != null && KarakterIcSesManager.Instance != null)
            KarakterIcSesManager.Instance.PlayInnerVoice(cocukCagirdi, innerVoiceTime);

        Debug.Log("cocuk çaðýrma tamam");

        opern = true;
    }

    IEnumerator RotateKapak(bool open)
    {
        kapakHareket = true;

        float targetAngle = open ? openAngle : closeAngle;

        while (true)
        {
            float currentY = kapakPivot.localEulerAngles.y;
            if (currentY > 180) currentY -= 360;

            float newY = Mathf.MoveTowards(
                currentY,
                targetAngle,
                rotateSpeed * Time.deltaTime
            );

            kapakPivot.localEulerAngles = new Vector3(
                kapakPivot.localEulerAngles.x,
                newY,
                kapakPivot.localEulerAngles.z
            );

            if (Mathf.Abs(newY - targetAngle) < 0.1f)
                break;

            yield return null;
        }

        kapakAcik = open;
        kapakHareket = false;
    }



}
