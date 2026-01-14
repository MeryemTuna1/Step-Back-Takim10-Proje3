using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    [Header("Door Sounds")]
    public AudioClip openDoorClip;
    public AudioClip closeDoorClip;

    private bool isOpen = false;

    void OnMouseDown()
    {
        if (isOpen) return;

        isOpen = true;
        StartCoroutine(OpenCloseDoor());
    }

    IEnumerator OpenCloseDoor()
    {
        //  Kapý açýlma sesi
        SFXAudioManager.Instance.PlaySFX(openDoorClip, 1f);

        // (Ýstersen burada animasyon / SetActive(false) yaparsýn)
        this.gameObject.SetActive(false);

        //  2 saniye bekle
        yield return new WaitForSeconds(2f);

        //  Kapý kapanma sesi
        SFXAudioManager.Instance.PlaySFX(closeDoorClip, 1f);

        // (Ýstersen kapýyý geri açarsýn)
        // this.gameObject.SetActive(true);
    }
}
