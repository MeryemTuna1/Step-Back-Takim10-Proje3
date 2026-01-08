using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesaj : MonoBehaviour
{
    public string mesajT;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            KarakterIcSesManager.Instance.ShowText(mesajT);
            //CameraManager.Instance.SwitchToTopDown();
        }
    }
}
