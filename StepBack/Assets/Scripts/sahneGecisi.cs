using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sahneGeçişi : MonoBehaviour
{
    public string sceneName;

    [Header("Yaka Kartı")]
    public GameObject yakaKarti;   // Boyundaki kart objesi

    private void OnMouseDown()
    {
        //  Yaka kartı yoksa veya aktif değilse geçme
        if (yakaKarti == null) return;
        if (!yakaKarti.activeInHierarchy) return;

        //  Yaka kartı AKTİFSE sahne geç
        SceneManager.LoadScene(sceneName);
        CameraManager.Instance.SwitchToThirdPerson();
    }
}
