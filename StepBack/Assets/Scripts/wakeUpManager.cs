using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wakeUpManager : MonoBehaviour
{
    public CanvasGroup blackScreen;
    public AudioSource alarmSource;

    IEnumerator Start()
    {
        blackScreen.alpha = 1;
        yield return new WaitForSeconds(3f);

       // alarmSource.Play();

        for (float a = 1; a >= 0; a -= Time.deltaTime)
        {
            blackScreen.alpha = a;
            yield return null;
        }

        KarakterIcSesManager.Instance.ShowText(
            "Yine erken bir sabah...");
    }
}
