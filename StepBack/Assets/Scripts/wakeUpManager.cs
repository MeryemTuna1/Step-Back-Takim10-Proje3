using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wakeUpManager : MonoBehaviour
{
    [Header("UI")]
    public CanvasGroup blackScreen;

    [Header("Audio Clips")]
    public AudioClip alarmClip;
   

   

    private AudioSource alarmSource;
    private bool alarmStopped = false;

    IEnumerator Start()
    {
        // Baþlangýç
        blackScreen.alpha = 1f;

        // Alarm baþlasýn
        StartAlarm();

        yield return new WaitForSeconds(2f);

        // Siyah ekran açýlma
        for (float a = 1; a >= 0; a -= Time.deltaTime)
        {
            blackScreen.alpha = a;
            yield return null;
        }
    }

    //  Alarmý baþlat
    void StartAlarm()
    {
        alarmSource = SFXAudioManager.Instance.PlayLoopSFX(alarmClip);
    }

    //  BUTONA BAÐLANACAK FONKSÝYON
    public void StopAlarm()
    {
        if (alarmStopped) return;

        alarmStopped = true;

        // Alarmý durdur
        SFXAudioManager.Instance.StopLoopSFX(alarmSource);

        // Ýç ses (yazý + ses)
       
    }
}
