using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    [Header("Hinge (Door Pivot)")]
    public Transform doorHinge;

    [Header("Rotation")]
    public float openAngle = 90f;
    public float rotateSpeed ; // derece/sn gibi düþün

    [Header("Audio")]
    public AudioClip openDoorClip;
    public AudioClip closeDoorClip;

    [Header("Player Animator (Optional)")]
    public Animator playerAnim;

    [Header("External (Optional)")]
    public dolapInteraktif open;

    private bool isOpen = false;
    private bool isBusy = false;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        if (doorHinge != null)
        {
            // GERÇEK kapalý pozisyon
            closedRotation = doorHinge.localRotation;

            // Kapalýdan açýk üret
            openRotation = closedRotation * Quaternion.Euler(0f, 0f, openAngle);
        }
    }

    void OnMouseDown()
    {
        if (isBusy) return;

        // Þart: sadece AÇARKEN kontrol et
        if (!isOpen && open != null && !open.opern)
            return;

        // TOGGLE
        if (isOpen)
            StartCoroutine(CloseDoor());
        else
            StartCoroutine(OpenDoor());
    }

    IEnumerator OpenDoor()
    {
        isBusy = true;

        if (playerAnim != null)
            playerAnim.SetTrigger("Open");

        if (openDoorClip != null)
            SFXAudioManager.Instance.PlaySFX(openDoorClip, 1f);

        yield return StartCoroutine(RotateDoor(openRotation));

        isOpen = true;
        isBusy = false;
    }

    IEnumerator CloseDoor()
    {
        isBusy = true;

        if (playerAnim != null)
            playerAnim.SetTrigger("Close");

        if (closeDoorClip != null)
            SFXAudioManager.Instance.PlaySFX(closeDoorClip, 1f);

        yield return StartCoroutine(RotateDoor(closedRotation));

        isOpen = false;
        isBusy = false;
    }

    IEnumerator RotateDoor(Quaternion targetRot)
    {
        while (Quaternion.Angle(doorHinge.localRotation, targetRot) > 0.1f)
        {
            doorHinge.localRotation = Quaternion.RotateTowards(
                doorHinge.localRotation,
                targetRot,
                rotateSpeed * Time.deltaTime
            );
            yield return null;
        }

        doorHinge.localRotation = targetRot;
    }
}
