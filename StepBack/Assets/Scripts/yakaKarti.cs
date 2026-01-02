using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yakaKarti : MonoBehaviour
{
    public GameObject badgeOnNeck;
    bool taken = false;

    void OnMouseDown()
    {
        if (taken) return;
        taken = true;

        gameObject.SetActive(false);      // dolaptaki kart kaybolur
        badgeOnNeck.SetActive(true);       // boyundaki kart görünür

        KarakterIcSesManager.Instance.ShowText(
            "Kartýmý almadan çýkamam."
        );
    }
}
