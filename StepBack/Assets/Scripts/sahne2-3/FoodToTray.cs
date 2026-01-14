using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodToTray : MonoBehaviour
{
    bool used = false;
    public AudioClip innerVoiceClip;
    void OnMouseDown()
    {
        if (used) return;

        TrayCarrySystem player = FindObjectOfType<TrayCarrySystem>();
        if (player.currentTray == null) return;

        player.PutFoodOnTray(gameObject);

        used = true;

        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);

        CameraManager.Instance.SwitchToThirdPerson();
    }
}
