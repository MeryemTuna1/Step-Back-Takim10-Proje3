using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    [Header("Hinge (Door Pivot)")]
    public Transform doorHinge;

    [Header("Rotation")]
    public float openAngle = 90f;
    public float rotateSpeed = 3f;
    public float openDuration;

    [Header("Player")]
    public Animator playerAnim;

    [Header("Audio")]
    public AudioClip openDoorClip;
    public AudioClip closeDoorClip;

    public dolapInteraktif open;

    private bool isBusy = false;
    private Quaternion closedRotation;

    void Start()
    {
        if (doorHinge != null)
            closedRotation = doorHinge.localRotation;
    }

    void OnMouseDown()
    {
        // BU FONKSÝYON SADECE DOLAP COLLIDER'INA TIKLANINCA ÇALIÞIR
        //if (isBusy) return;

        if(open.opern)
        {
            StartCoroutine(DoorRoutine());
        }

       
    }

    IEnumerator DoorRoutine()
    {
        isBusy = true;

        Quaternion openRotation = Quaternion.Euler(
            doorHinge.localEulerAngles.x,
            doorHinge.localEulerAngles.y,
            doorHinge.localEulerAngles.z + openAngle
        );

        // Player OPEN
        if (playerAnim != null)
            playerAnim.SetTrigger("Open");

        // Kapýyý aç
        SFXAudioManager.Instance.PlaySFX(openDoorClip, 1f);
        yield return StartCoroutine(RotateDoor(openRotation));

        yield return new WaitForSeconds(openDuration);

        // Player CLOSE
        if (playerAnim != null)
            playerAnim.SetTrigger("Close");

        // Kapýyý kapa
        SFXAudioManager.Instance.PlaySFX(closeDoorClip, 1f);
        yield return StartCoroutine(RotateDoor(closedRotation));

        isBusy = false;
    }

    IEnumerator RotateDoor(Quaternion targetRot)
    {
        while (Quaternion.Angle(doorHinge.localRotation, targetRot) > 0.1f)
        {
            doorHinge.localRotation = Quaternion.Slerp(
                doorHinge.localRotation,
                targetRot,
                Time.deltaTime * rotateSpeed
            );
            yield return null;
        }

        doorHinge.localRotation = targetRot;
    }




    /*
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

        gameObject.SetActive(true);

        // Close anim süresi
        yield return new WaitForSeconds(1.5f);

        
    }*/
}
