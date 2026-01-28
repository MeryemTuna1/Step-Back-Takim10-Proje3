using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LonelyTableSit : MonoBehaviour
{
    public Transform trayPlacePoint;

    [Header("Yemekhane NPC'leri")]
    public GameObject[] cafeteriaNPCs;

    [Header("Ofis Davetiyesi")]
    public GameObject invitationObject;
    bool used = false;

    public AudioClip innerVoiceClip, innerVoiceClip2;

    private void Start()
    {
        invitationObject.SetActive(false);
    }

    void OnMouseDown()
    {
        if (used) return;

        TrayCarrySystem player = FindObjectOfType<TrayCarrySystem>();
        if (player.currentTray == null) return;

        // Tepsiyi masaya koy
        player.PlaceTrayOnTable(trayPlacePoint);

        // Kamera TopDown
        //CameraManager.Instance.SwitchToTopDown();

        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);

        used = true;

        StartCoroutine(AfterEating());
    }

    IEnumerator AfterEating()
    {
        yield return new WaitForSeconds(5f);

        // Kamera 3rd Person
        //CameraManager.Instance.SwitchToThirdPerson();

        // нч ses
        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip2);

        invitationObject.SetActive(true);

        // NPC'leri yok et
        foreach (GameObject npc in cafeteriaNPCs)
        {
            npc.SetActive(false);
        }

       
    }

}
