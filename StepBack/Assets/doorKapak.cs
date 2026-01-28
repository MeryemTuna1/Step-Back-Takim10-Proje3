using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorKapak : MonoBehaviour
{
    [Header("Hinge (Door Pivot)")]
    public Transform doorHinge;

    [Header("Rotation")]
    public float openAngle = 90f;
    public float rotateSpeed = 3f;

    private bool isOpen = false;
    private bool isBusy = false;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        if (doorHinge != null)
        {
            closedRotation = doorHinge.localRotation;

            openRotation = Quaternion.Euler(
                doorHinge.localEulerAngles.x,
                doorHinge.localEulerAngles.y + openAngle,
                doorHinge.localEulerAngles.z 
            );
        }
    }

    //  SEKANS ÝÇÝN
    public void OpenFromSequence()
    {
        if (isBusy || isOpen) return;
        StartCoroutine(OpenDoor());
    }

    public void CloseFromSequence()
    {
        if (isBusy || !isOpen) return;
        StartCoroutine(CloseDoor());
    }

    IEnumerator OpenDoor()
    {
        isBusy = true;
        yield return StartCoroutine(RotateDoor(openRotation));
        isOpen = true;
        isBusy = false;
    }

    IEnumerator CloseDoor()
    {
        isBusy = true;
        yield return StartCoroutine(RotateDoor(closedRotation));
        isOpen = false;
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
}
