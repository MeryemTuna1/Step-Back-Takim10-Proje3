using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvitationInteract : MonoBehaviour
{
    public Transform carryPoint;
    public float inspectDuration = 3f;

    Vector3 startPos;
    Quaternion startRot;

    bool used = false;

    public AudioClip innerVoiceClip, innerVoiceClip1;
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    void OnMouseDown()
    {
        if (used) return;
        used = true;

        StartCoroutine(InspectRoutine());
    }

    IEnumerator InspectRoutine()
    {
        CameraManager.Instance.SwitchToFirstPerson();

        // Davetiye ele gelsin
        transform.SetParent(carryPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        // Kamera davetiyeye baksýn
        CameraManager.Instance.LookAtTarget(transform);

        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);

        yield return new WaitForSeconds(inspectDuration);

        // Davetiye eski yerine dönsün
        transform.SetParent(null);
        transform.position = startPos;
        transform.rotation = startRot;

        CameraManager.Instance.StopLookAt();

        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip1);

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("EvOnu");
    }
}

