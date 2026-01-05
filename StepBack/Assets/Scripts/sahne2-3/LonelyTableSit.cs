using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LonelyTableSit : MonoBehaviour
{
    public Transform trayPlacePoint;

    bool used = false;

    void OnMouseDown()
    {
        if (used) return;

        TrayCarrySystem player = FindObjectOfType<TrayCarrySystem>();
        if (player.currentTray == null) return;

        // Tepsiyi masaya koy
        player.PlaceTrayOnTable(trayPlacePoint);

        // Kamera TopDown
        CameraManager.Instance.SwitchToTopDown();

        KarakterIcSesManager.Instance.ShowText(
            "Burada oturabilirim."
        );

        used = true;

        // 5 saniye sonra 3rd person'a dön
        StartCoroutine(ReturnToThirdPerson());
    }

    IEnumerator ReturnToThirdPerson()
    {
        yield return new WaitForSeconds(5f);

        CameraManager.Instance.SwitchToThirdPerson();
    }
}
