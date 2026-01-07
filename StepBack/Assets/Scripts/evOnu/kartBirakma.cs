using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kartBirakma : MonoBehaviour
{
    public GameObject badgeOnNeck;
    bool taken = false;
    public string text;
  
    void OnMouseDown()
    {
        if (taken) return;
        taken = true;

        badgeOnNeck.SetActive(false);      // dolaptaki kart kaybolur
        gameObject.SetActive(true);       // boyundaki kart görünür

        KarakterIcSesManager.Instance.ShowText(text);

        bitisManager.Instance.FadeToBlack();
    }
}
