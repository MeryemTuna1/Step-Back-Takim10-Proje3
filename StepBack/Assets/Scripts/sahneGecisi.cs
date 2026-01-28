using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sahneGeçişi : MonoBehaviour
{
    public string sceneName;

    [Header("Condition")]
    public yakaKarti yakaKarti;   // yaka kartı referansı

    private void OnMouseDown()
    {
        //  Yaka kartı alınmadıysa geçemez
        if (yakaKarti != null && !yakaKarti.taken)
        {
            Debug.Log("Yaka kartı alınmadan sahne geçilemez!");
            return;
        }

        //  Şart sağlandı → geç
        SceneManager.LoadScene(sceneName);

        if (CameraManager.Instance != null)
            CameraManager.Instance.SwitchToThirdPerson();
    }
}
