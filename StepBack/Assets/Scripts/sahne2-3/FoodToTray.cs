using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodToTray : MonoBehaviour
{
    bool used = false;

    void OnMouseDown()
    {
        if (used) return;

        TrayCarrySystem player = FindObjectOfType<TrayCarrySystem>();
        if (player.currentTray == null) return;

        player.PutFoodOnTray(gameObject);

        used = true;

        KarakterIcSesManager.Instance.ShowText(
            "Yemek az olabilir… hemen çýkarým."
        );

        CameraManager.Instance.SwitchToThirdPerson();
    }
}
