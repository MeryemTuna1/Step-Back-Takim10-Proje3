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

    [Header("Door")]
    public doorKapak door;   //KAPAK SCRIPTÝ

    [Header("State")]
    public bool opern = false;

    private bool used = false;

    public alarmInteract ok;

    void OnMouseDown()
    {
        if (used) return;

        if (!ok.alarm)
        {
            Debug.Log("Alarm aktif deðil, dolap açýlamaz!");
            return;
        }

        //  SADECE alarm true ise kilitle
        used = true;

        CameraManager.Instance.SwitchToThirdPerson();
        StartCoroutine(DolapSequence());

    }

    IEnumerator DolapSequence()
    {
        //  Ses
        if (dolapOpenClip != null)
            SFXAudioManager.Instance.PlaySFX(dolapOpenClip, 1f);

        //  KAPAÐI AÇ
        if (door != null)
            door.OpenFromSequence();

        yield return new WaitForSeconds(2f);

        // Ýç ses
        if (innerVoiceClip != null && KarakterIcSesManager.Instance != null)
            KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip, innerVoiceTime);

        //  KAPANMA SESÝ
        if (dolapCloseClip != null)
            SFXAudioManager.Instance.PlaySFX(dolapCloseClip, 1f);

        yield return new WaitForSeconds(0.5f); //  garanti için küçük bekleme

        //  KAPAÐI KAPA
        if (door != null)
            door.CloseFromSequence();

        yield return new WaitForSeconds(4f);

        // Çocuk çaðýrma
        if (cocukCagirdi != null && KarakterIcSesManager.Instance != null)
            KarakterIcSesManager.Instance.PlayInnerVoice(cocukCagirdi, innerVoiceTime);

        opern = true;
        Debug.Log("Dolap sekansý + kapak tamamlandý");
    }

}
