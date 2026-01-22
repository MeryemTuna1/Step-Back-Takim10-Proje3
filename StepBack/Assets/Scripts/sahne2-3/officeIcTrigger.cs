using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class officeIcTrigger : MonoBehaviour
{
    public float shrinkSpeed = 0.3f;
    public float targetScale = 0.85f;
    public AudioClip innerVoiceClip;
    bool shrinking = false;

    void Update()
    {
        if (!shrinking) return;

        if (transform.localScale.x > targetScale)
        {
            transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CameraManager.Instance.SwitchToThirdPerson();

            shrinking = true;

            KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);
        }
    }
}
