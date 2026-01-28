using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class officeTrigger : MonoBehaviour
{
    public GameObject officeDistorted;
    public GameObject officeNormal;
    public AudioClip innerVoiceClip;
    // public AudioSource hornSound;

    public float shakeDuration = 1.2f;
    public float shakePower = 0.15f;

    bool triggered = false;
    private void Start()
    {
        CameraManager.Instance.SwitchToThirdPerson();
    }
    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;
        StartCoroutine(OfficeShockSequence());
     
    }

    IEnumerator OfficeShockSequence()
    {
        // Ofisi bozuk göster
        officeDistorted.SetActive(true);
        officeNormal.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        // KORNA
        //hornSound.Play();

        // FPS'e geç
        CameraManager.Instance.SwitchToFirstPerson();

        Camera fpsCam = CameraManager.Instance.GetActiveCamera();


        // Kamera titremesi
        
        FirstPersonCameraController fpsController =
            fpsCam.GetComponent<FirstPersonCameraController>();

        if (fpsController != null)
        {
            fpsController.StartShake(1.2f, 0.15f);
        }

        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);

        

        yield return new WaitForSeconds(3f);

        // Ofisi normale döndür
        officeDistorted.SetActive(false);
        officeNormal.SetActive(true);
        // 3rd person
        CameraManager.Instance.SwitchToThirdPerson();

        
    }
}
