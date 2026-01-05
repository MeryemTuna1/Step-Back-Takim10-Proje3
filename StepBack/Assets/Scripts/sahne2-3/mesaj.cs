using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesaj : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            KarakterIcSesManager.Instance.ShowText("Yine geç kaldým.");
            CameraManager.Instance.SwitchToTopDown();
        }
    }
}
