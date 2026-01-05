using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableRejection : MonoBehaviour
{
    //yemekhane arkadaþlarý

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        KarakterIcSesManager.Instance.ShowText(
            "Beni Ýstemiyorlar yine"
        );

        // Sandalyeler kapanabilir (opsiyonel)
    }
}
