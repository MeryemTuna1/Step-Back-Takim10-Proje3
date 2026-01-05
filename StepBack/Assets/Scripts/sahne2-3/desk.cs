using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desk : MonoBehaviour
{
    bool used = false;

    void OnTriggerEnter(Collider other)
    {
        if (used) return;
        if (!other.CompareTag("desk")) return;

        used = true;

        // Kamera FPS
        CameraManager.Instance.SwitchToFirstPerson();

        // Ýç ses
        KarakterIcSesManager.Instance.ShowText(
            "Keþke görünmez olsaydým..."
        );

        // Masada oturma hissi için hareketi kilitlemek istersen:
        // other.GetComponent<PlayerMovement>().enabled = false;

        // Canavar sekansýný baþlat
        FindObjectOfType<OfficeMonsterSequence>().StartSequence();
    }
}
