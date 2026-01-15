using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{


    public Animator anim;
    public AudioClip openDoorClip;
    public AudioClip closeDoorClip;

    private bool isUsed = false;

    void OnMouseDown()
    {
        if (isUsed) return;
        isUsed = true;

        StartCoroutine(DoorRoutine());
    }

    IEnumerator DoorRoutine()
    {
        // Idle'a DÖNDÜKTEN SONRA objeyi kapat
        gameObject.SetActive(false);

        // Kapý açýlýyor
        anim.SetTrigger("Open");
        SFXAudioManager.Instance.PlaySFX(openDoorClip, 1f);

        // Open anim süresi (clip süresi kadar)
        yield return new WaitForSeconds(1.5f);

        // Kapý kapanýyor
       // anim.SetTrigger("Close");
        SFXAudioManager.Instance.PlaySFX(closeDoorClip, 1f);

        // Close anim süresi
        yield return new WaitForSeconds(1.5f);

        
    }
}
