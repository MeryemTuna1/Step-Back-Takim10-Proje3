using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesaj1 : MonoBehaviour
{
    public string mesajTx;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            KarakterIcSesManager.Instance.ShowText(mesajTx);
            CameraManager.Instance.SwitchToFirstPerson();
        }
    }
}
