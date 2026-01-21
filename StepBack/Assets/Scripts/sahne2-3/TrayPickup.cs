using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayPickup : MonoBehaviour
{
    public AudioClip clip;

    void OnMouseDown()
    {
        TrayCarrySystem player = FindObjectOfType<TrayCarrySystem>();
        player.TakeTray(gameObject);

        GetComponent<Collider>().enabled = false;

        KarakterIcSesManager.Instance.PlayInnerVoice(clip);
    }
}
