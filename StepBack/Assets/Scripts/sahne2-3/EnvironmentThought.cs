using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentThought : MonoBehaviour
{
    
    bool used = false;

    void OnTriggerEnter(Collider other)
    {
        if (used) return;
        if (!other.CompareTag("Player")) return;

        used = true;
        KarakterIcSesManager.Instance.ShowText("etrafý izleyim");
    }
}
